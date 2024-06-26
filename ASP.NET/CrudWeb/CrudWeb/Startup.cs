using CrudWeb.Configuration;
using CrudWeb.DataAccess.Contexts;
using CrudWeb.DataAccess.Repositories;
using CrudWeb.Services;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;

namespace CrudWeb
{
    public class Startup(IConfiguration configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup).Assembly);

            var connectionString = configuration.GetConnectionString("ProductsDbConnection");
            services.AddDbContext<ProductsDbContext>(
                options => options.UseNpgsql(connectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductsService, ProductsService>();
            services.AddMvc();
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSpaStaticFiles(config =>
            {
                var settings = configuration.GetSection(SpaSettings.Key).Get<SpaSettings>();
                config.RootPath = settings.RootPath;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                //.AllowAnyOrigin()
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
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                var settings = configuration.GetSection(SpaSettings.Key).Get<SpaSettings>();
                spa.Options.SourcePath = settings.SourcePath;
                spa.Options.DevServerPort = 4200;
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer("start");
                }
            });
            Console.WriteLine($"ContentRoot Path: {env.ContentRootPath}");
            Console.WriteLine($"WebRootPath: {env.WebRootPath}");
        }

        private string[] GetAllowedOrigins(IConfiguration config) =>
            config.GetSection("AllowedOrigins").Get<string[]>() ?? [];
    }
}