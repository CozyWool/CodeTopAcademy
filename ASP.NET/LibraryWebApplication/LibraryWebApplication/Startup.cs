using LibraryWebApplication.Binders;
using LibraryWebApplication.DataAccess.Contexts;
using LibraryWebApplication.DataAccess.Repositories;
using LibraryWebApplication.Middlewares;
using LibraryWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddAutoMapper(typeof(Startup).Assembly);
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IBookRepository, DbBookRepository>();
        services.AddScoped<IBookService, DbBookService>();
        services.AddMvc();
        
        services.AddOptions<MvcOptions>()
            .Configure<ILoggerFactory, IHttpContextAccessor>((options, loggerFactory, httpContextAccessor) =>
            {
                options.ModelBinderProviders.Insert(0, new IndexRequestModelBinderProvider(loggerFactory, httpContextAccessor));
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        if (env.IsDevelopment())
        {
            // app.UseDeveloperExceptionPage();
        }

        app.UseStatusCodePages();
        app.UseRouting();
        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Library}/{action=Index}/{id?}");
        });
    }
}