using Microsoft.EntityFrameworkCore;
using ShopDemo.DataAccess.Entities;

namespace ShopDemo.DataAccess.Contexts;

public class CarsDbContext : DbContext
{
    public CarsDbContext()
    {
    }

    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }

    

    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.ShortDescription);
            entity.Property(e => e.LongDescription);
            entity.Property(e => e.Image).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.IsFavourite).IsRequired();
            entity.Property(e => e.Available).IsRequired();
            entity.Property(e => e.CategoryId).IsRequired();
        });
        modelBuilder.Entity<CategoryEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CategoryName).IsRequired();
            entity.Property(e => e.Description);
        });

        modelBuilder.Entity<CategoryEntity>()
            .HasMany(e => e.Cars)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();

        modelBuilder.Entity<CarEntity>()
            .HasOne(e => e.Category)
            .WithMany(e => e.Cars)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();
        
        SeedData(modelBuilder);
    }
    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>().HasData(new()
            {
                Id = 1, CategoryName = "Электромобили", Description = "Современный вид транспорта"
            },
            new()
            {
                Id = 2, CategoryName = "Классические автомобили",
                Description = "Машины с двигателем внутреннего сгорания"
            });

        modelBuilder.Entity<CarEntity>().HasData(new()
            {
                Id = 1,
                Name = "Corolla",
                ShortDescription = "Автомобиль, выпускаемый компанией Toyota",
                LongDescription =
                    "НОВЫЙ АВТОМОБИЛЬ. Изготовлен 05.2023г. ПРИВЕЗЕН С КИТАЯ АВТОВОЗОМ.\nРастаможен в России. ЭПТС в наличии.",
                Image = "/img/corolla.jpg",
                Price = 2_190_000,
                IsFavourite = false,
                Available = true,
                CategoryId = 2
            },
            new()
            {
                Id = 2,
                Name = "Ford Mustang",
                ShortDescription = "Легковой автомобиль класса Pony Car производства Ford Motor Company",
                LongDescription = "В хорошем состоянии. Родной пробег. Привезен из Америки.",
                Image = "/img/Ford-Mustang-gt-500.jpg",
                Price = 4_250_000,
                IsFavourite = false,
                Available = true,
                CategoryId = 2
            },
            new()
            {
                Id = 3,
                Name = "Corolla",
                ShortDescription =
                    "Семейство российских автомобилей среднего класса, выпускаемых АвтоВАЗом с 25 сентября 2015 года в кузове седан, и с 2017 года в кузове универсал.",
                LongDescription =
                    "Автомобиль Lada Vesta I, 2021 года выпуска, в отличном состоянии, 1 хозяин. Весь в заводском окрасе, с пробегом всего 49500 км. Это надежный и экономичный седан, оснащенный 1.6-литровым бензиновым двигателем мощностью 106 лошадиных сил. Коробка передач - механика.",
                Image = "/img/lada-vesta.jpg",
                Price = 1_210_000,
                IsFavourite = false,
                Available = true,
                CategoryId = 2
            },
            new()
            {
                Id = 4,
                Name = "Corolla",
                ShortDescription = "Автомобиль, выпускаемый компанией Toyota",
                LongDescription =
                    "НОВЫЙ АВТОМОБИЛЬ. Изготовлен 05.2023г. ПРИВЕЗЕН С КИТАЯ АВТОВОЗОМ.\nРастаможен в России. ЭПТС в наличии.",
                Image = "/img/corolla.jpg",
                Price = 2_190_000,
                IsFavourite = false,
                Available = true,
                CategoryId = 2
            },
            new()
            {
                Id = 5,
                Name = "Ford Mustang",
                ShortDescription = "Легковой автомобиль класса Pony Car производства Ford Motor Company",
                LongDescription = "В хорошем состоянии. Родной пробег. Привезен из Америки.",
                Image = "/img/Ford-Mustang-gt-500.jpg",
                Price = 4_250_000,
                IsFavourite = false,
                Available = true,
                CategoryId = 2
            });
    }
}