using AuthRolesWeb.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthRolesWeb.DataAccess.Contexts;

public class UserDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}