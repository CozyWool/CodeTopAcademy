using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}