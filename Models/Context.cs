/**
 * Author: Kamalpreet Mundi, Gurnoor Aujila, Tyler Lam
 * 
 * This class is kind of like a dictionary for the models.
 * By using this context class, we organize all the models into a  single class, in this case being the context class.
 * And can simply call this class to call on the other models.
 * 
 * 
 * 
 * 
 * **/


using Microsoft.EntityFrameworkCore;

namespace CPSC471_Proj.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)   
            : base(options)
        {
        }

        // All models for the liquor table (from database)
        public DbSet<Liquor> Liquor { get; set; }

        public DbSet<LiquorName> LiquorName { get; set; }

        public DbSet<LiquorDescription> LiquorDescription { get; set; }

        public DbSet<LiquorImage> LiquorImage { get; set; }

        public DbSet<LiquorPrice> LiquorPrice { get; set; }

        public DbSet<LiquorSalePercentage> LiquorSalePercentage { get; set; }

        public DbSet<LiquorSaleLength> LiquorSaleLength { get; set; }

        public DbSet<LiquorQuantity> LiquorQuantity { get; set; }

        public DbSet<LiquorVolume> LiquorVolume { get; set; }

        // Models for the Store table (from database)
        public DbSet<StoreName> StoreName { get; set; }
    }
}
