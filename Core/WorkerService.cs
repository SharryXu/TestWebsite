using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestWebsite.Core
{
    public class WorkerService : IHostedService
    {
        private IHostApplicationLifetime _lifetime;
        private ILogger<BackgroundService> _logger;

        public WorkerService(IHostApplicationLifetime lifetime, ILogger<BackgroundService> logger)
        {
            _lifetime = lifetime;
            _logger = logger;
            _lifetime.ApplicationStarted.Register(() => _logger.LogInformation($"lifetime.ApplicationStarted"));
            _lifetime.ApplicationStopped.Register(() => _logger.LogInformation($"lifetime.ApplicationStopped"));
            _lifetime.ApplicationStopping.Register(() => _logger.LogInformation($"lifetime.ApplicationStopping"));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(StartAsync)}.{cancellationToken.IsCancellationRequested}.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(StopAsync)}.{cancellationToken.IsCancellationRequested}.");
            return Task.CompletedTask;
        }
    }
}