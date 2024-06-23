using Microsoft.Extensions.Configuration;
using Serilog;

Thread.CurrentThread.Name = "Example logging with Serilog";

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json",true)
    .Build();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configurationBuilder)
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .Enrich.WithAssemblyName()
    .Enrich.WithAssemblyVersion()
    .CreateLogger();

logger.Verbose("Verbose логированние");
logger.Debug("Debug логированние");
logger.Information("Information логированние");
logger.Warning("Warning логированние");
logger.Error("Error логированние");
logger.Fatal("Fatal логированние");
logger.Information("Логгирование завершено");