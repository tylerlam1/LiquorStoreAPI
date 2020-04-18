using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorQuantity
    {
        [Key]
        public int liquor_id { get; set; }

        public int quantity { get; set; }
    }
}