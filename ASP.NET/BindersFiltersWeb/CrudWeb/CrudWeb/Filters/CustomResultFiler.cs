using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudWeb.Filters;

public class CustomResultFilter : IResultFilter
{
    private readonly ILogger<CustomResultFilter> _logger;
    private Stopwatch _timer;

    public CustomResultFilter(ILogger<CustomResultFilter> logger)
    {
        _logger = logger;
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        _logger.LogInformation($"Время обработки результата: {_timer.Elapsed.TotalSeconds:F6}");
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        _timer = Stopwatch.StartNew();
        context.HttpContext.Response.Headers.Add("current-date", DateTime.Now.ToShortDateString());
    }
}