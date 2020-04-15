using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorPrice
    {
        [Key]
        public int liquor_id { get; set; }

        public double price { get; set; }
    }
}