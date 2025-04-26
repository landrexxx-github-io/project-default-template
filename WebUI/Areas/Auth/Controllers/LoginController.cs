using Microsoft.AspNetCore.Mvc;

namespace Financev1.Areas.Auth.Controllers;

[Area("Auth")]
[Route("[area]/[controller]")]
public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}