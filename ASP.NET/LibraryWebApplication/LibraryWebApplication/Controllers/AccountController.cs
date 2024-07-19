using System.Security.Claims;
using LibraryWebApplication.Models;
using LibraryWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApplication.Controllers;

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
        ViewBag.Title = "Вход";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        if (await _userService.Login(model))
            return !string.IsNullOrEmpty(returnUrl) ? Redirect(returnUrl) : RedirectToAction("Index", "Library");

        ModelState.AddModelError("", "Неверный пароль или логин");
        return View(model);
    }


    [HttpGet]
    public IActionResult Register(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        ViewBag.Title = "Регистрация";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        if (await _userService.Register(model))
            return !string.IsNullOrEmpty(returnUrl) ? Redirect(returnUrl) : RedirectToAction("Index", "Library");

        ModelState.AddModelError("", "Некорректные логин или(и) пароль");
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        if (await _userService.Logout())
            return RedirectToAction("Login", "Account");
        return RedirectToAction("Index", "Library");
    }

    public async Task<IActionResult> AccessDenied(string? returnUrl = null)
    {
        ViewData["ErrorMessage"] = "Доступ к странице запрещен";
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

}