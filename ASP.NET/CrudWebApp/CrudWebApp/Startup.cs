using CrudWebApp.DataAccess.Contexts;
using CrudWebApp.DataAccess.Repositories;
using CrudWebApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApp;

public class Startup
{
    private IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("ProductsDbConnection");
        services.AddDbContext<ProductsDbContext>(options
            => options.UseNpgsql(connectionString));
        services.AddScoped<IProductRepository, DbProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(typeof(Startup).Assembly);

        // services.AddControllers();
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            // endpoints.MapControllers();
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        Console.WriteLine($"ContentRoot Path: {env.ContentRootPath}");
        Console.WriteLine($"WebRootPath: {env.WebRootPath}");
    }
}