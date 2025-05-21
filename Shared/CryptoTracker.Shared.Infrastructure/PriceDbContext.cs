using Microsoft.EntityFrameworkCore;
using CryptoTracker.Shared.Domain;


namespace CryptoTracker.Shared.Infrastructure 
{ 
    public class PriceDbContext(DbContextOptions options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<PriceRecord> PriceRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
}


