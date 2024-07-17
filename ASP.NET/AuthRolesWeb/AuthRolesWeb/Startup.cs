using AuthRolesWeb.DataAccess.Contexts;
using AuthRolesWeb.DataAccess.Repositories;
using AuthRolesWeb.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace AuthRolesWeb;

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

        services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("AuthDbConnection")));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new PathString(CookieAuthenticationDefaults.LoginPath);
                options.LogoutPath = new PathString(CookieAuthenticationDefaults.LogoutPath);
                options.AccessDeniedPath = new PathString(CookieAuthenticationDefaults.AccessDeniedPath);
                options.Cookie.HttpOnly = true;
            });

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}