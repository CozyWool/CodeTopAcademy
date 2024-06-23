using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(
    builder =>
    {
        builder
            .AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Debug);
    });
var logger = loggerFactory.CreateLogger<Program>();

logger.LogTrace("Trace логированние");
logger.LogDebug("Debug логированние");
logger.LogInformation("Information логированние");
logger.LogWarning("Warning логированние");
logger.LogError("Error логированние");
logger.LogCritical("Critical логированние");