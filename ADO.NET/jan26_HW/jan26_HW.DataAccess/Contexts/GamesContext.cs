using jan26_HW.DataAccess.Configurations;
using jan26_HW.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace jan26_HW.DataAccess.Contexts;

public class GamesContext : DbContext
{
    private readonly IConfiguration _configuration;

    public GamesContext(IConfiguration configuration)
    {
        _configuration = configuration;
        Database.EnsureCreated();
    }

    public GamesContext(DbContextOptions<GamesContext> options) : base(options)
    {
        
    }
    
    public DbSet<GameEntity> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("GamesConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameConfiguration).Assembly);
    }
}