using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using bdoProject.Api.Extensions.Auth;
using bdoProject.Api.Extensions.GraphQL;
using bdoProject.Api.Filters;
using bdoProject.Application;
using bdoProject.Application.Behaviors;
using bdoProject.Application.Features.Auth.Commands.LogIn;
using bdoProject.Infrastructure;
using FluentValidation;
using MediatR;

namespace bdoProject.Api.Extensions.Core;

public static class ServerExtensions
{
    public static IServiceCollection AddServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddControllers(o => o.Filters.Add<ResultFilter>())
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        services.AddValidatorsFromAssembly(typeof(LoginCommand).Assembly);
        services.AddInfrastructure(configuration);
        services.AddGraphQlConfiguration();
        services.AddHttpContextAccessor();
        services.AddApplication();

        services.AddEndpointsApiExplorer();
        services.AddJwtAuth(configuration);
        services.AddSwaggerGen(options =>
        {
            options.SchemaFilter<EnumSchemaFilter>();
        });
        services.AddServerCors();
        services.AddGraphQlRateLimiting();

        return services;
    }

    private static IServiceCollection AddServerCors(this IServiceCollection services)
    {
        services.AddCors(cors =>
        {
            cors.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("https://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }

    private static IServiceCollection AddGraphQlRateLimiting(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddPolicy("graphql", context =>
            {
                var partitionKey = context.User.Identity?.IsAuthenticated == true
                    ? context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "anonymous"
                    : context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                var isAuthenticated = context.User.Identity?.IsAuthenticated == true;

                return RateLimitPartition.GetSlidingWindowLimiter(partitionKey, _ => new SlidingWindowRateLimiterOptions
                {
                    PermitLimit = isAuthenticated ? 100 : 20,
                    Window = TimeSpan.FromMinutes(1),
                    SegmentsPerWindow = 6,
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                    QueueLimit = 0
                });
            });

            options.OnRejected = async (context, cancellationToken) =>
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                context.HttpContext.Response.Headers.RetryAfter = "60";

                await context.HttpContext.Response.WriteAsJsonAsync(new
                {
                    errors = new[]
                    {
                        new { message = "Rate limit exceeded. Please try again later." }
                    }
                }, cancellationToken);
            };
        });

        return services;
    }
}