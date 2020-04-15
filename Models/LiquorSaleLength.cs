using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorSaleLength
    {
        [Key]
        public int liquor_id { get; set; }

        public int sale_length { get; set; }
    }
}