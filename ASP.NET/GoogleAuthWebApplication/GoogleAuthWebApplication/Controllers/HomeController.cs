using GoogleAuthWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoogleAuthWebApplication.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GoogleAuthWebApplication.Controllers;
public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<HomeController> _logger;

    public HomeController(UserManager<AppUser> userManager, ILogger<HomeController> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> Privacy()
    {
        var user = await _userManager.GetUserAsync(User);
        var message = $"Hello {user?.UserName}";
        return View("Privacy", message);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
