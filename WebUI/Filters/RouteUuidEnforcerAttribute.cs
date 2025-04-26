using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Financev1.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class RouteUuidEnforcerAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Skip if already has Uuid
        if (context.RouteData.Values.TryGetValue("id", out var id) &&
            !string.IsNullOrEmpty(id?.ToString()))
        {
            if (IsValidGuid(id.ToString())) return;
            context.Result = new BadRequestObjectResult("Page not found.");
            return;
        }
        
        // Get the current route values
        var routeValues = context.RouteData.Values;
        var area = routeValues["area"]?.ToString();
        var controller = routeValues["controller"]?.ToString();
        var action = routeValues["action"]?.ToString();
        
        // Generate new UUID
        var newUuid = Guid.NewGuid().ToString().ToLower();
            
        // Build redirect route values
        var newRouteValues = new RouteValueDictionary(new { id = newUuid });

        if (area != null)
            newRouteValues.Add("area", area);
        
        // Redirect to include UUID in url
        context.Result = new RedirectToActionResult(
            action!,
            controller!,
            newRouteValues);
    }

    private static bool IsValidGuid(string? guidString)
    {
        if (string.IsNullOrEmpty(guidString))
            return false;
        
        return Guid.TryParseExact(guidString, "D", out _) || 
               Guid.TryParseExact(guidString, "N", out _);
    }
}