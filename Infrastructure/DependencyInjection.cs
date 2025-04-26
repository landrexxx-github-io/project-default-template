using System.Security.Claims;
using Application;
using Application.Menu;
using Domain.Entities;
using Domain.DTO;
using Infrastructure.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration config)
    {
        // Make sure this context is available to all layers
        services.AddScoped<ConfigContext>(sp =>
        {
            var httpContext = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
            var userId = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = httpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
            var connectionString = config.GetConnectionString("DefaultConnection");

            return new ConfigContext
            {
                UserId = int.Parse(userId!),
                Username = username!,
                ConnectionString = connectionString!
            };
        });
        
        return services;
    }
    
    /*
     * Auth
     * Created by: Landrex O. Rebuera
     * Created date: April 10, 2025
     */
    public static IServiceCollection AddAuthInfrastructure(this IServiceCollection services)
    {
        return services;
    }
    
    public static IServiceCollection AddManageInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<AppMenu>, MenuRepository>();
        services.AddScoped<IGenericService<AppMenu>, MenuService>();
        
        return services;
    }
}