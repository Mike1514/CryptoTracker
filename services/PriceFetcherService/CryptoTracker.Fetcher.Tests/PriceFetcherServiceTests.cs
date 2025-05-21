using System.Net;
using System.Text;
using CryptoTracker.Fetcher.Infrastructure.Services;
using CryptoTracker.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;

public class PriceFetcherServiceTests
{
    [Fact]
    public async Task FetchAndStorePriceAsync_Should_SavePriceRecord_When_ApiReturnsValidData()
    {
        // Arrange
        var expectedPrice = 43000.25m;
        var json = $"{{ \"USD\": {expectedPrice} }}";

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(handlerMock.Object);

        var options = new DbContextOptionsBuilder<PriceDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var dbContext = new PriceDbContext(options);

        var serviceProviderMock = new Mock<IServiceProvider>();
        var scopeMock = new Mock<IServiceScope>();
        var scopeFactoryMock = new Mock<IServiceScopeFactory>();

        scopeMock.Setup(x => x.ServiceProvider).Returns(serviceProviderMock.Object);
        serviceProviderMock.Setup(x => x.GetService(typeof(IServiceScopeFactory))).Returns(scopeFactoryMock.Object);
        serviceProviderMock.Setup(x => x.GetService(typeof(PriceDbContext))).Returns(dbContext);

        scopeFactoryMock.Setup(x => x.CreateScope()).Returns(scopeMock.Object);

        var loggerMock = new Mock<ILogger<PriceFetcherService>>();

        var service = new PriceFetcherService(httpClient, serviceProviderMock.Object, loggerMock.Object);

        // Act
        await service.FetchAndStorePriceAsync(CancellationToken.None);

        // Assert
        var savedRecord = await dbContext.PriceRecords.FirstOrDefaultAsync();
        Assert.NotNull(savedRecord);
        Assert.Equal(expectedPrice, savedRecord!.Value);
    }
}
