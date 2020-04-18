using Microsoft.EntityFrameworkCore;

namespace CPSC471_Proj.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Liquor> Liquor { get; set; }

        public DbSet<LiquorName> LiquorName { get; set; }

        public DbSet<LiquorDescription> LiquorDescription { get; set; }

        public DbSet<LiquorImage> LiquorImage { get; set; }

        public DbSet<LiquorPrice> LiquorPrice { get; set; }

        public DbSet<LiquorSalePercentage> LiquorSalePercentage { get; set; }

        public DbSet<LiquorSaleLength> LiquorSaleLength { get; set; }

        public DbSet<LiquorQuantity> LiquorQuantity { get; set; }

        public DbSet<LiquorVolume> LiquorVolume { get; set; }

        public DbSet<StoreName> StoreName { get; set; }
    }
}
