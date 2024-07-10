using System.Text.Json;
using Microsoft.Extensions.Options;
using MiddlewareWeb.Configurations;

namespace MiddlewareWeb.Middlewares;

public class StudentsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly StudentsOptions _options;

    public StudentsMiddleware(RequestDelegate next, IOptions<StudentsOptions> options)
    {
        _next = next;
        _options = options.Value ?? throw new ArgumentException(null, nameof(options));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        if (context.Request.Path == "/students")
        {
            await context.Response.WriteAsJsonAsync(_options);
        }
        else
        {
            await _next(context);
        }
    }
}