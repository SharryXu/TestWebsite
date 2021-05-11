using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;

namespace TestWebsite.Core
{
    public class WorkerService : IHostedService
    {
        private IHostApplicationLifetime _lifetime;
        private Logger _logger;

        public WorkerService(IHostApplicationLifetime lifetime, ILogger<BackgroundService> logger)
        {
            _lifetime = lifetime;
            _logger = new NLog.LogFactory().GetCurrentClassLogger();

            _lifetime.ApplicationStarted.Register(() => _logger.LogInformation($"lifetime.ApplicationStarted"));
            _lifetime.ApplicationStopped.Register(() => _logger.LogInformation($"lifetime.ApplicationStopped"));
            _lifetime.ApplicationStopping.Register(() => _logger.LogInformation($"lifetime.ApplicationStopping"));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(StartAsync)}.{cancellationToken.IsCancellationRequested}.");

            await Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    _logger.LogInformation($"Current time is: {DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}.");

                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
            }, TaskCreationOptions.LongRunning);

            _logger.LogInformation($"{nameof(StartAsync)}.FinishStart");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(StopAsync)}.{cancellationToken.IsCancellationRequested}.");
            return Task.CompletedTask;
        }
    }

    public static class LogExtensions
    {
        public static void LogInformation(this Logger logger, string message)
        {
            logger.Log(NLog.LogLevel.Info, message);
        }
    }
}