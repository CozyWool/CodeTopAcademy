using EfCoreWpf.DataAccess.Configuration;
using EfCoreWpf.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfCoreWpf.DataAccess.Contexts;

public sealed class BooksContext : DbContext
{
    private readonly IConfiguration _configuration;

    public BooksContext(IConfiguration configuration)
    {
        _configuration = configuration;
        Database.EnsureCreated();
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public DbSet<AuthorEntity> Authors { get; set; }

    public DbSet<BookEntity> Books { get; set; }

    public DbSet<PublisherEntity> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // => optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["BooksCodeFirst"].ConnectionString);
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("BooksConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);

        modelBuilder.HasSequence("Book_AuthorId_seq");
        modelBuilder.HasSequence("Book_Id_seq");
        modelBuilder.HasSequence("Book_PublisherId_seq");
        modelBuilder.HasSequence("Publisher_Id_seq");
    }
}