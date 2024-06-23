namespace DemoWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        // app.MapGet("/", () => "Hello World!");
        // app.MapGet("/counter", () => 42);
        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapControllers();
        
        app.Run();
    }
}