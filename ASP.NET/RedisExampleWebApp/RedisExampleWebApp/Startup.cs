using System.Text;
using Consul;
using Microsoft.EntityFrameworkCore;
using RedisExampleWebApp.Configuration;
using RedisExampleWebApp.DataAccess.Contexts;

namespace RedisExampleWebApp;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        var client = new ConsulClient(clientConfiguration =>
            clientConfiguration.Address = new Uri(configuration.GetSection("ConsulUrl").Value ?? "http://localhost:8500"));

        var getPair = client.KV.Get(configuration.GetSection("AppSettingsKey").Value ?? throw new NullReferenceException("AppSettingsKey was null")).Result;
        var value = Encoding.UTF8.GetString(getPair.Response.Value, 0, getPair.Response.Value.Length);
        File.WriteAllText("appsettings.json", value);


        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ProductDbConnection")));


        services.AddControllersWithViews();

        services.AddStackExchangeRedisCache(options =>
        {
            var settings = new RedisCacheSettings();
            configuration.GetSection(RedisCacheSettings.ConfigurationKey).Bind(settings);

            options.Configuration = settings.Configuration;
            options.InstanceName = settings.InstanceName;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        else
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseRouting();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapControllerRoute("default",
                "{controller=Home}/{action=Index}/{id?}");
        });
    }
}