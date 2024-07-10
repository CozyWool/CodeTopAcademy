namespace MiddlewareWeb.Middlewares;

public class QueryStringMiddleware
{
    private readonly RequestDelegate _next;

    public QueryStringMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
        {
            // context.Response.ContentType = "text/plain";

            await context.Response.WriteAsync("Custom class Middleware\n");
        }

        await _next(context);
    }
}