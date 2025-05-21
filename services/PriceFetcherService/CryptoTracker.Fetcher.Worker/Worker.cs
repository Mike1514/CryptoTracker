using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CryptoTracker.Fetcher.Application.Interfaces;

namespace CryptoTracker.Fetcher.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPriceFetcherService _priceFetcherService;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

        public Worker(ILogger<Worker> logger, IPriceFetcherService priceFetcherService)
        {
            _logger = logger;
            _priceFetcherService = priceFetcherService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(_interval);

            _logger.LogInformation("Worker started. Running every {Interval}", _interval);

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    await _priceFetcherService.FetchAndStorePriceAsync(stoppingToken);
                    _logger.LogInformation("Price fetched and stored successfully at {Time}", DateTime.UtcNow);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during price fetching and storing");
                }
            }

            _logger.LogInformation("Worker stopped.");
        }
    }
}
