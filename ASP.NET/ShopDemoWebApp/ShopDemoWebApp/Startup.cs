using ShopDemoWebApp.DataAccess.Repositories;

namespace ShopDemoWebApp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICarsRepository, FakeCarsRepository>();
        // Если нужно прокинуть данные в конструктор
        // services.AddScoped<ICarsRepository>(p =>
        // {
        //     var r = p.GetService<ICarCategoryRepository>();
        //     return new FakeCarsRepository(r);
        // });
        services.AddScoped<ICarCategoryRepository, FakeCarCategoryRepository>();
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStatusCodePages();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            // endpoints.MapGet("/", () => "Hello world!");
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Cars}/{action=List}/{id?}");
        });
    }
}