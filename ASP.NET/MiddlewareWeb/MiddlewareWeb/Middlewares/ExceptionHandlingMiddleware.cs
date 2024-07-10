using System.Net;

namespace MiddlewareWeb.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An unexpected exception");

        var response = new ExceptionResponse();
        switch (exception)
        {
            case ApplicationException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "Application exception occurred.";
                break;
            case ArgumentNullException:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "Argument null exception occurred.";
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = "Bad request exception occurred.";
                break;
        }
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }

    private class ExceptionResponse()
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}