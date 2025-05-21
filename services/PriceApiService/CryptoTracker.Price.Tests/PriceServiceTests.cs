using Microsoft.EntityFrameworkCore;
using CryptoTracker.Price.Infrastructure.Services;
using CryptoTracker.Shared.Infrastructure;
using CryptoTracker.Shared.Domain;

public class PriceServiceTests
{
    [Fact]
    public async Task GetPricesAsync_ReturnsCorrectData()
    {
        var options = new DbContextOptionsBuilder<PriceDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        await using var context = new PriceDbContext(options);
        context.PriceRecords.Add(new PriceRecord
        {
            Id = Guid.NewGuid(),
            Time = DateTime.UtcNow,
            Value = 45000.99m
        });
        await context.SaveChangesAsync();

        var service = new PriceService(context);
        var result = await service.GetPricesAsync(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(1));

        Assert.Single(result);
    }
}
