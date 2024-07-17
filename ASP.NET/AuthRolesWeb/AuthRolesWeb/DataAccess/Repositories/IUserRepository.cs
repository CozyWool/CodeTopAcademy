using AuthRolesWeb.DataAccess.Entities;

namespace AuthRolesWeb.DataAccess.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> GetUserByEmail(string email);
    Task Create(UserEntity entity);
}