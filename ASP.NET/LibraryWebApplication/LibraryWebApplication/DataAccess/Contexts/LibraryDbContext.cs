using LibraryWebApplication.DataAccess.Configurations;
using LibraryWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.DataAccess.Contexts;

public class LibraryDbContext : DbContext
{

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookEntity> Books { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
    }
}