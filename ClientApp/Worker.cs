using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var clientAppPath = $@"{System.IO.Directory.GetCurrentDirectory()}\ClientApp\";

            var processInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                RedirectStandardInput = true,
                WorkingDirectory = clientAppPath
            };

            var process = Process.Start(processInfo);

            await process.StandardInput.WriteLineAsync("npm run serve & exit");
            await process.WaitForExitAsync();
        }
    }
}
