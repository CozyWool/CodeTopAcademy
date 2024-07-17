using AuthRolesWeb.Models;
using AuthRolesWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthRolesWeb.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        if (await _userService.Login(model))
            return !string.IsNullOrEmpty(returnUrl) ? Redirect(returnUrl) : RedirectToAction("Index", "Home");

        ModelState.AddModelError("", "Неверный пароль или логин");
        return View(model);
    }


    [HttpGet]
    public IActionResult Register(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        if (await _userService.Register(model))
            return !string.IsNullOrEmpty(returnUrl) ? Redirect(returnUrl) : RedirectToAction("Index", "Home");

        ModelState.AddModelError("", "Некорректные логин или(и) пароль");
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        if (await _userService.Logout())
            return RedirectToAction("Login", "Account");
        return RedirectToAction("Error", "Home");
    }

    public async Task<IActionResult> AccessDenied()
    {
        ViewData["ErrorMessage"] = "Доступ к странице запрещен";
        return View();
    }
}