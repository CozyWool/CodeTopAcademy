using LibraryWebApplication.DataAccess.Configurations;
using LibraryWebApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.DataAccess.Contexts;

public partial class LibraryDbContext : DbContext
{

    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookEntity> Books { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}