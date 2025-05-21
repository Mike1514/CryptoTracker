using Microsoft.EntityFrameworkCore;
using CryptoTracker.Price.Application.DTOs;
using CryptoTracker.Price.Application.Interfaces;
using CryptoTracker.Price.Application.Mappers;
using CryptoTracker.Shared.Infrastructure;


namespace CryptoTracker.Price.Infrastructure.Services;

public class PriceService : IPriceService
{
    private readonly PriceDbContext _dbContext;

    public PriceService(PriceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PriceRecordDto>> GetPricesAsync(DateTime from, DateTime to)
    {
        var records = await _dbContext.PriceRecords
            .Where(p => p.Time >= from && p.Time<= to)
            .ToListAsync();

        return records.Select(PriceDtoMapper.ToDto);
    }
}
