using bdoProject.Api.Extensions.Auth;
using bdoProject.Api.Middleware;

namespace bdoProject.Api.Extensions.Core;

public static class ApplicationExtensions
{
    public static WebApplication UseApplication(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseStaticFiles();
        app.UseCors();

        app.UseValidationProblemDetails();

        app.UseHttpsRedirection();

        app.UseJwtAuth();

        app.UseRateLimiter();

        app.MapControllers();

        app.MapGraphQL("/graphql")
            .RequireRateLimiting("graphql");

        return app;
    }
}