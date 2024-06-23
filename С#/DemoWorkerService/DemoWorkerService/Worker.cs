using Microsoft.Extensions.Options;
using System.Text;

namespace DemoWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DirectorySettings _directoriesSettings;
        private string _directory = @"C:\Users\vserg\Downloads\TestServiceFolder";

        public Worker(IOptions<DirectorySettings> options,ILogger<Worker> logger)
        {
            _logger = logger;
            _directoriesSettings = options.Value ?? throw new ArgumentNullException(nameof(DirectorySettings));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var directories = Directory.GetDirectories(_directory);
                var files = Directory.GetFiles(_directory);
                if (!directories.Any()) 
                {
                    _logger.LogWarning("Directories not found");
                }
                else
                {
                    StringBuilder sb = new();
                    sb.AppendLine("Directories:");
                    sb.AppendLine(string.Join("; ", directories));
                    _logger.LogInformation(sb.ToString());
                }
                if (!files.Any()) 
                {
                    _logger.LogWarning("Files not found");
                }
                else
                {
                    StringBuilder sb = new();
                    sb.AppendLine("Files:");
                    sb.AppendLine(string.Join("; ", files));
                    _logger.LogInformation(sb.ToString());
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(Worker)}: Start");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(Worker)}: stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}