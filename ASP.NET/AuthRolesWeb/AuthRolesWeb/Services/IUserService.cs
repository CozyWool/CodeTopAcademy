using AuthRolesWeb.Models;

namespace AuthRolesWeb.Services;

public interface IUserService
{
    Task<bool> Login(LoginModel model);
    Task<bool> Logout();
    Task<bool> Register(RegisterModel model);
}