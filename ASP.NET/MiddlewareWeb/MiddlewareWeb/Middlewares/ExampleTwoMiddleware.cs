namespace MiddlewareWeb.Middlewares;

public class ExampleTwoMiddleware
{
    private readonly RequestDelegate _next;

    public ExampleTwoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path != "/example-2")
        {
            await _next(context);
            return;
        }

        if (!context.Response.HasStarted)
        {
            context.Response.Headers.Append("qwerty", "Hello world");
            context.Response.Headers.Append("Framework", "ASP.NET core");
        }

        await context.Response.WriteAsync("Example 2 page with 2 custom headers");
    }
}