using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CryptoTracker.Shared.Infrastructure;

namespace CryptoTracker.Fetcher.Infrastructure.DbContext
{
    public class PriceDbContextFactory : IDesignTimeDbContextFactory<PriceDbContext>
    {
        public PriceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../CryptoTracker.Fetcher.Worker")))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PriceDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CryptoTrackerDb"),
                x => x.MigrationsAssembly("CryptoTracker.Fetcher.Infrastructure"));

            return new PriceDbContext(optionsBuilder.Options);
        }
    }
}
