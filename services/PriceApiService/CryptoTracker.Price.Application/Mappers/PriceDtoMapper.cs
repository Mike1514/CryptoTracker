using CryptoTracker.Price.Application.DTOs;
using CryptoTracker.Shared.Domain;

namespace CryptoTracker.Price.Application.Mappers;
public static class PriceDtoMapper
{
    public static PriceRecordDto ToDto(PriceRecord record) => new()
    {
        Time = record.Time,
        Value = record.Value
    };
}
