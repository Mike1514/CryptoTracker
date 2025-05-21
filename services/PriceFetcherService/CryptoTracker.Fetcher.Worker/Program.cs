using CryptoTracker.Fetcher.Application.Interfaces;
using CryptoTracker.Shared.Infrastructure;
using CryptoTracker.Fetcher.Infrastructure.Services;
using CryptoTracker.Fetcher.Worker;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IPriceFetcherService, PriceFetcherService>();
builder.Services.AddDbContext<PriceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CryptoTrackerDb")));

var host = builder.Build();
host.Run();
