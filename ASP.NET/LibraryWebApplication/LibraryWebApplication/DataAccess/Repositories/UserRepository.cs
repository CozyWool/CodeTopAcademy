using LibraryWebApplication.DataAccess.Contexts;
using LibraryWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LibraryDbContext _dbContext;

    public UserRepository(LibraryDbContext dbContext)
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