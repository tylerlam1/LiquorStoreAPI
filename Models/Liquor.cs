using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class Liquor
    {
        [Key]
        public int liquor_id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public float price { get; set; }

        public int quantity { get; set; }

        public string description { get; set; }

        public int supplier_id { get; set; }

        public int clerk_id { get; set; }

        public string image_link { get; set; }

        public int bottle_volume { get; set; }

        public float sale_percentage { get; set; }

        public int sale_length { get; set; }
    }
}
