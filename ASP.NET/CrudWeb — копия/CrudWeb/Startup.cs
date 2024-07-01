using CrudWeb.DataAccess.Contexts;
using CrudWeb.DataAccess.Repositories;
using CrudWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace CrudWeb;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup).Assembly);

        services.AddHttpContextAccessor();

        var connectionString = configuration.GetConnectionString("ProductsDbConnection");
        services.AddDbContext<ProductsDbContext>(
            options => options.UseNpgsql(connectionString));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<IFileService, FileService>();
        services.AddMvc();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(x => x
            .WithOrigins(GetAllowedOrigins(configuration))
            .AllowAnyMethod()
            .AllowAnyHeader());

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
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
        Console.WriteLine($"ContentRoot Path: {env.ContentRootPath}");
        Console.WriteLine($"WebRootPath: {env.WebRootPath}");
    }

    private string[] GetAllowedOrigins(IConfiguration config) =>
        config.GetSection("AllowedOrigins").Get<string[]>() ?? [];
}