using Microsoft.AspNetCore.Diagnostics;

namespace Financev1.Exceptions;

public static class GlobalExceptionHandler
{
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = exceptionHandlerFeature?.Error;

                if (exception != null)
                {
                    var problemDetails = ProblemDetailsConfiguration.CreateProblemDetails(
                        context,
                        exception,
                        context.RequestServices.GetRequiredService<IWebHostEnvironment>()
                    );
                    
                    context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
                    
                    await context.Response.WriteAsJsonAsync(problemDetails);
                }
            });
        });
    }
}