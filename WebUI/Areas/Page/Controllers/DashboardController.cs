using Microsoft.AspNetCore.Mvc;

namespace Financev1.Areas.Page.Controllers;

[Area("Page")]
[Route("page/dashboard")]
public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}