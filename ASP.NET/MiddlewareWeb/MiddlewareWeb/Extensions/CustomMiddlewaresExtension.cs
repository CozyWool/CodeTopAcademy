using MiddlewareWeb.Middlewares;

namespace MiddlewareWeb.Extensions;

public static class CustomMiddlewaresExtension
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
    {
        return builder
            .UseMiddleware<QueryStringMiddleware>()
            .UseMiddleware<StudentsMiddleware>()
            .UseMiddleware<ExampleTwoMiddleware>();
    }
}