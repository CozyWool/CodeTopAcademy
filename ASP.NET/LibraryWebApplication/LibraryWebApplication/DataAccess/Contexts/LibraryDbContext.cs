using LibraryWebApplication.DataAccess.Configurations;
using LibraryWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.DataAccess.Contexts;

public class LibraryDbContext : DbContext
{

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
        // Console.WriteLine(Database.GenerateCreateScript());
    }

    public virtual DbSet<BookEntity> Books { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
    }
}