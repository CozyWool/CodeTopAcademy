using System.Configuration;
using EfCoreWpf.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreWpf;

public class BooksDbContextFactory : IDesignTimeDbContextFactory<BooksContext>
{
    public BooksContext CreateDbContext(string[] args)
    {
        const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=d3k7f4l8b5r4;Database=Books;";
        var optionsBuilder = new DbContextOptionsBuilder<BooksContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new BooksContext(optionsBuilder.Options);
    }
}