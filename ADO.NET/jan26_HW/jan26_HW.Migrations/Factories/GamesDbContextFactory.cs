using jan26_HW.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace jan26_HW.Migrations.Factories;

public class GamesDbContextFactory : IDesignTimeDbContextFactory<GamesContext>
{
    public GamesContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GamesContext>();
        optionsBuilder.UseNpgsql(builder =>
        {
            builder.MigrationsAssembly(typeof(GamesDbContextFactory).Assembly.FullName);
        });
        return new GamesContext(optionsBuilder.Options);
    }
}