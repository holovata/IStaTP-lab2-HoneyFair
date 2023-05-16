using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace holovataLab2HoneyFair.Models
{
    public class HoneyFairContext: DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<HoneyType> HoneyTypes { get; set;}
        public virtual DbSet<HoneyRegion> HoneyRegions { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<FairLocation> FairLocations { get; set; }
        public HoneyFairContext(DbContextOptions<HoneyFairContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
