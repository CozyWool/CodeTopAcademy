using LibraryWebApplication.Binders;
using LibraryWebApplication.DataAccess.Contexts;
using LibraryWebApplication.DataAccess.Repositories;
using LibraryWebApplication.Middlewares;
using LibraryWebApplication.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();

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
        // services.AddAuthorization(options =>
        //     options.AddPolicy("OnlyForAdult",
        //         policy => policy.RequireClaim("IsAdult", "true")));

        services.AddMvc();
        services.AddOptions<MvcOptions>()
            .Configure<IHttpContextAccessor>((options, httpContextAccessor) =>
            {
                options.ModelBinderProviders.Insert(0, new IndexRequestModelBinderProvider(httpContextAccessor));
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStatusCodePages();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Library}/{action=Index}/{id?}");
        });
    }
}