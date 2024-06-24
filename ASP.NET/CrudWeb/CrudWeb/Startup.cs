using System;
using CrudWeb.DataAccess.Contexts;
using CrudWeb.DataAccess.Repositories;
using CrudWeb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
            Console.WriteLine($"ContentRoot Path: {env.ContentRootPath}");
            Console.WriteLine($"WebRootPath: {env.WebRootPath}");
        }
    }
}
