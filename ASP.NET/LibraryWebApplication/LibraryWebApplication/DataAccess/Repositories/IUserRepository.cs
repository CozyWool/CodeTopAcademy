using LibraryWebApplication.DataAccess.Entities;

namespace LibraryWebApplication.DataAccess.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> GetUserByEmail(string email);
    Task Create(UserEntity entity);
}