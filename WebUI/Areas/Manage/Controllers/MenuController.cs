using Financev1.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Financev1.Areas.Manage.Controllers;

[Area("Manage")]
[Route("[area]/[controller]/{id?}")]
public class MenuController : Controller
{
    [RouteUuidEnforcer]
    public IActionResult Index(string id)
    {
        return View();
    }
    
    
}