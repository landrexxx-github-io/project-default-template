using Microsoft.AspNetCore.Mvc;

namespace Financev1.Controllers;

[Route("menu")]
public class MenuController : Controller
{
    public IActionResult Index()
    {
        return Ok();
    }
}