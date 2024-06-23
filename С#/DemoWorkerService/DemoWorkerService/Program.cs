using DemoWorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureLogging((_, logging) => 
    {
        logging.AddConsole();
        logging.AddEventLog(new Microsoft.Extensions.Logging.EventLog.EventLogSettings
        {
            SourceName = nameof(DemoWorkerService),
            LogName = $"{nameof(DemoWorkerService)}-Log",
        });
    })
    .ConfigureServices((context,services) =>
    {
        services.Configure<DirectorySettings>(options => context.Configuration.GetSection(DirectorySettings.DirectoriesKey));
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
