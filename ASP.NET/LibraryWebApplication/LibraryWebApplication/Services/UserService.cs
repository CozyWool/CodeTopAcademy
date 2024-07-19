using System.Security.Claims;
using LibraryWebApplication.DataAccess.Entities;
using LibraryWebApplication.DataAccess.Repositories;
using LibraryWebApplication.Enums;
using LibraryWebApplication.Helpers;
using LibraryWebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LibraryWebApplication.Services;

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

        await Authenticate(model.Email, user.Role, model.RememberMe, user.Birthday);
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
            CreatedDate = DateTimeOffset.UtcNow,
            Birthday = model.Birthday
        };
        await _userRepository.Create(userEntity);

        await Authenticate(model.Email, model.Role, false, model.Birthday);
        return true;
    }

    private async Task Authenticate(string email, Role role, bool rememberMe, DateOnly birthday)
    {
        // Не люблю я работу с датами, так что https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
        var age = DateTime.Now.Year - birthday.Year;


        if (birthday.ToDateTime(new TimeOnly()) > DateTime.Now.AddYears(-age))
            age--;

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, role.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim("IsAdult", (age >= 18).ToString())
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