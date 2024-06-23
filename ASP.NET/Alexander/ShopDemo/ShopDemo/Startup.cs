using Microsoft.EntityFrameworkCore;
using ShopDemo.DataAccess.Contexts;
using ShopDemo.DataAccess.Repositories;

namespace ShopDemo;

public class Startup
{
    private IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<ICarsRepository, DbCarsRepository>()
            .AddScoped<ICarCategoryRepository, DbCarCategoryRepository>();
        /* https://stackoverflow.com/questions/38709538/no-service-for-type-microsoft-aspnetcore-mvc-viewfeatures-itempdatadictionaryfa
        services.AddMvcCore();*/
        services.AddMvc();
        // services.AddRazorPages();
        // services.AddControllersWithViews();
        Console.WriteLine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        var connectionString = _configuration.GetConnectionString("CarsDbConnection");
        services.AddDbContext<CarsDbContext>(options => options.UseNpgsql(connectionString));
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
            //аналогичное поведение даст
            //endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Cars}/{action=List}/{id?}");
            // endpoints.MapControllers();
            // endpoints.MapRazorPages();
        });
    }
}