using AuthRolesWeb.DataAccess.Contexts;
using AuthRolesWeb.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthRolesWeb.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext;

    public UserRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserEntity?> GetUserByEmail(string email) =>
        await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task Create(UserEntity entity)
    {
        _dbContext.Users.Add(entity);
        await _dbContext.SaveChangesAsync();
    }
}