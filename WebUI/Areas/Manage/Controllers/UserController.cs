using Microsoft.AspNetCore.Mvc;

namespace Financev1.Areas.Manage.Controllers;

[Area("Manage")]
[Route("[area]/[controller]")]
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}