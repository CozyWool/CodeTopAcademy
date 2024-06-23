using CrudWebApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApp.DataAccess.Contexts;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext()
    {
        
    }
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<CategoryEntity> Categories { get; set; }

    public virtual DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_category_id_fkey");
        });
        
        modelBuilder.Entity<CategoryEntity>().HasData(
            new CategoryEntity {Id = 1, Name = "Electronics"},
            new CategoryEntity {Id = 2, Name = "Books"}
        );
        modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity {Id = 1, Name = "Smartphone", Price = 500, CategoryId = 1},
            new ProductEntity {Id = 2, Name = "Laptop", Price = 1500, CategoryId = 1},
            new ProductEntity {Id = 3, Name = "Fiction Book", Price = 20, CategoryId = 2}
        );
    }
}