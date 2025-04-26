using Microsoft.AspNetCore.Mvc;

namespace Financev1.Areas.Manage.Controllers;

[Area("Manage")]
[Route("[area]/[controller]")]
public class RoleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}