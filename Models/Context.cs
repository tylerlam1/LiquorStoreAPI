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
    }
}
