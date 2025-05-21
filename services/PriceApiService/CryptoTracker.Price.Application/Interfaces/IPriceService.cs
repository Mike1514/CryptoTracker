using CryptoTracker.Price.Application.DTOs;

namespace CryptoTracker.Price.Application.Interfaces;

public interface IPriceService
{
    Task<IEnumerable<PriceRecordDto>> GetPricesAsync(DateTime from, DateTime to);
}
