using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using System.Reflection;
using ElkConsoleApp;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "development";
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
    .Enrich.WithProperty("Environment", environment)
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Log.Logger.Verbose("Verbose логгирование");
Log.Logger.Debug("Debug логгирование");
Log.Logger.Information("Information логгирование");
Log.Logger.Warning("Warning логгирование");
Log.Logger.Error("Error логгирование");
Log.Logger.Fatal("Fatal логгирование");
Log.Logger.Information("Логирование завершено");

var logger = Log.Logger;
var someData = new SomeData
{
    Field1 = "Поле 1",
    Field2 = "Поле 2",
    Field3 = "Поле 3",
    Date = DateTime.Now
};
for (int i = 0; i < 1_000; i++)
{
    logger.Information("{@Some}", someData);
}

Log.CloseAndFlush();

static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    var indexFormat =
        $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}";
    return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = indexFormat
    };
}