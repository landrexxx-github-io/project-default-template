using Financev1.Exceptions.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Financev1.Exceptions;

public static class ProblemDetailsConfiguration
{
    public static ProblemDetails CreateProblemDetails(
        HttpContext context,
        Exception exception,
        IWebHostEnvironment webHostEnvironment)
    {

        var (statusCode, title) = exception switch
        {
            ValidationException => (StatusCodes.Status400BadRequest, "Validation Error"),
            NotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error"),
        };
        
        return new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message,
            Instance = context.Request.Path,
            Type = GetTypeReference(statusCode),
            Extensions = { { "traceId", context.TraceIdentifier } }
        };
    }

    private static string GetTypeReference(int statusCode) => statusCode switch
    {
        StatusCodes.Status400BadRequest => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
        StatusCodes.Status401Unauthorized => "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
        StatusCodes.Status404NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
        StatusCodes.Status500InternalServerError => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
        _ => "https://datatracker.ietf.org/doc/html/rfc7231"
    };
}