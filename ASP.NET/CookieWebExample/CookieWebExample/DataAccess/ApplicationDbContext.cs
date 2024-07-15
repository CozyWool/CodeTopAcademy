using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookieWebExample.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}