using CryptoTracker.Fetcher.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using CryptoTracker.Shared.Domain;
using CryptoTracker.Shared.Infrastructure;


namespace CryptoTracker.Fetcher.Infrastructure.Services
{
    public class PriceFetcherService : IPriceFetcherService
    {
        private readonly HttpClient _httpClient;
        private readonly IServiceProvider _services;
        private readonly ILogger<PriceFetcherService> _logger;

        public PriceFetcherService(HttpClient httpClient, IServiceProvider services, ILogger<PriceFetcherService> logger)
        {
            _httpClient = httpClient;
            _services = services;
            _logger = logger;
        }

        public async Task FetchAndStorePriceAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            var price = JsonDocument.Parse(json).RootElement.GetProperty("USD").GetDecimal();

            using var scope = _services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<PriceDbContext>();

            var record = new PriceRecord
            {
                Id = Guid.NewGuid(),
                Time = DateTime.UtcNow,
                Value = price
            };

            dbContext.PriceRecords.Add(record);
            await dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Saved price: {Price}", price);
        }
    }

}
