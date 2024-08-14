using System.Security.Claims;
using GoogleAuthWebApplication.DataAccess;
using GoogleAuthWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuthWebApplication.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        var login = new LoginModel {ReturnUrl = returnUrl};
        return View(login);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        if (!ModelState.IsValid) return View(loginModel);

        var user = await _userManager.FindByEmailAsync(loginModel.Email);
        if (user != null)
        {
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(user,
                loginModel.Password,
                loginModel.Remember,
                false);
            if (result.Succeeded)
            {
                return Redirect(loginModel.ReturnUrl ?? "/");
            }

            var emailStatus = await _userManager.IsEmailConfirmedAsync(user);
            if (emailStatus == false)
            {
                ModelState.AddModelError(nameof(loginModel.Email), "Email is unconfirmed, please confirm it first");
            }

            if (result.IsLockedOut)
                ModelState.AddModelError("",
                    "Your account is locked out. Kindly wait for 10 minutes and try again");
        }

        ModelState.AddModelError(nameof(loginModel.Email), "Invalid user");
        return View(loginModel);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult GoogleLogin()
    {
        var redirectUrl = Url.Action(nameof(GoogleResponse));
        var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        return new ChallengeResult("Google", properties);
    }

    [AllowAnonymous]
    public async Task<IActionResult> GoogleResponse()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null) return RedirectToAction(nameof(Login));
        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
        string[] userInfo =
        [
            info.Principal.FindFirst(ClaimTypes.Name).Value,
            info.Principal.FindFirst(ClaimTypes.Email).Value
        ];

        if (result.Succeeded)
        {
            return View(userInfo);
        }

        var user = new AppUser
        {
            Email = userInfo.Last(),
            UserName = userInfo.Last()
        };

        var identityResult = await _userManager.CreateAsync(user);
        if (!identityResult.Succeeded) return AccessDenied();

        identityResult = await _userManager.AddLoginAsync(user, info);
        if (!identityResult.Succeeded) return AccessDenied();

        await _signInManager.SignInAsync(user, false);
        return View(userInfo);
    }
}