using Microsoft.EntityFrameworkCore;
using RedisExampleWebApp.DataAccess.Entities;

namespace RedisExampleWebApp.DataAccess.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ProductEntity> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity(Guid.Parse("9F70608E-6C32-4B85-B75C-B714CAAAD5DE"), "Book", 130),
            new ProductEntity(Guid.Parse("D5727B1F-7110-455C-8552-6A0137BB061F"), "Smartphone", 150),
            new ProductEntity(Guid.Parse("1ECECF4B-4C5F-4013-BA5A-61FE5F488F37"), "Laptop", 220)
            );
    }
}