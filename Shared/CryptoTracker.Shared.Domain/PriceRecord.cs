namespace CryptoTracker.Shared.Domain;

public class PriceRecord
{
    public Guid Id { get; set; }
    public DateTime Time { get; set; }
    public decimal Value { get; set; }
}
