using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Application.Interfaces.Security;
using bdoProject.Infrastructure.Persistence;
using bdoProject.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bdoProject.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>((sp, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IDataContext>(sp => sp.GetRequiredService<DataContext>());

        var jwt = configuration.GetSection("Jwt").Get<JwtSettings>()!;
        services.AddSingleton(jwt);
        
        services.AddScoped<IJwtService, JwtService>();
        
        return services;
    }
}