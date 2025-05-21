using CryptoTracker.Fetcher.Application.DTOs;
using CryptoTracker.Shared.Domain;


namespace CryptoTracker.Fetcher.Application.Mappers
{
    public static class PriceDtoMapper
    {
        public static PriceRecord ToEntity(this PriceDto dto)
        {
            return new PriceRecord
            {
                Id = Guid.NewGuid(),
                Time = dto.Time,
                Value = dto.Value
            };
        }
    }

}
