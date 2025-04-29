using Financev1.Middlewares;

namespace Financev1.Exceptions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomExceptionHandler(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddScoped<ExceptionHandlingMiddleware>();
        
        return services;
    }
}