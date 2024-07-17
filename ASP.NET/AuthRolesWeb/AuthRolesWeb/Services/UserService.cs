using System.Security.Claims;
using AuthRolesWeb.DataAccess.Entities;
using AuthRolesWeb.DataAccess.Repositories;
using AuthRolesWeb.Helpers;
using AuthRolesWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AuthRolesWeb.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> Login(LoginModel model)
    {
        var user = await _userRepository.GetUserByEmail(model.Email);
        if (user == null || !SecurityHelper.PasswordMatch(model.Password, user.Id.ToString(), user.Password))
            return false;

        await Authenticate(model.Email, user.Role, model.RememberMe);
        return true;
    }

    public async Task<bool> Logout()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return true;
    }

    public async Task<bool> Register(RegisterModel model)
    {
        var user = await _userRepository.GetUserByEmail(model.Email);
        if (user != null) return false;

        var id = Guid.NewGuid();
        var hash = SecurityHelper.GenerateSaltedHash(model.Password, id.ToString());
        var userEntity = new UserEntity
        {
            Id = id,
            Email = model.Email,
            Password = hash,
            Role = model.Role,
            CreatedDate = DateTimeOffset.UtcNow
        };
        await _userRepository.Create(userEntity);

        await Authenticate(model.Email, model.Role, false);
        return true;
    }

    private async Task Authenticate(string email, string role, bool rememberMe)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Email, email)
        };
        var id = new ClaimsIdentity(claims,
            "ApplicationCookie",
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        await _httpContextAccessor.HttpContext
            .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id),
                new AuthenticationProperties {IsPersistent = rememberMe});
    }
}