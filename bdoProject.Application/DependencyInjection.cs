using bdoProject.Application.Behaviors;
using bdoProject.Application.Features.LeaveAndAbsence.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace bdoProject.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            // Registers IMediator, all IRequestHandlers, and IRequests from Application assembly
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            // Registers your open pipeline behavior (ValidationBehavior) with MediatR
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddScoped<IDaysCalculator, DaysCalculator>();

        return services;
    }
}