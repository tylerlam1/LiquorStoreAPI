using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorSalePercentage
    {
        [Key]
        public int liquor_id { get; set; }

        public float sale_percentage { get; set; }
    }
}
