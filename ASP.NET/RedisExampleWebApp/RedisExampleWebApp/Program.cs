using Microsoft.EntityFrameworkCore;
using RedisExampleWebApp.Configuration;
using RedisExampleWebApp.DataAccess.Contexts;

namespace RedisExampleWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ProductDbConnection")));
        builder.Services.AddControllersWithViews();

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            var settings = new RedisCacheSettings();
            builder.Configuration.GetSection(RedisCacheSettings.ConfigurationKey).Bind(settings);

            options.Configuration = settings.Configuration;
            options.InstanceName = settings.InstanceName;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}