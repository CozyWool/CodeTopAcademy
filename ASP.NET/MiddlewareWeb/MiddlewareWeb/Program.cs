using MiddlewareWeb.Configurations;
using MiddlewareWeb.Extensions;
using MiddlewareWeb.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", true, true);
// .AddJsonFile("appsettings.Development.json", true, true);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<StudentsOptions>(builder.Configuration.GetSection(StudentsOptions.Key));

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
// }
//
// app.UseStaticFiles();
//
// app.UseRouting();
//
// app.UseAuthorization();

//
// app.MapRazorPages();

// app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/example-1")
    {
        context.Response.ContentType = "text/html;charset=utf-8";
        await context.Response.WriteAsync("Страница example-1");
    }
    else
    {
        await next();
    }
});

app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware\n");
    }

    await next();
});

app.UseCustomMiddlewares();

app.MapWhen(context => context.Request.Path == "/exception",
    applicationBuilder => applicationBuilder.Run(context => throw context.Request.Query["code"].ToString() switch
    {
        "500" => new ArgumentNullException(),
        "404" => new ApplicationException(),
        _ => new NullReferenceException()
    }));
// app.MapGet("/exception",
//     context => throw context.Request.Query["code"].ToString() switch
//     {
//         "500" => new ArgumentNullException(),
//         "404" => new ApplicationException(),
//         _ => new NullReferenceException()
//     });
app.MapGet("/index", () => "Hello world");
app.Run();