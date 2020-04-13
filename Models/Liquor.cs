using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPSC471_Proj.Models
{
    public class Liquor
    {
        [Key]
        public int liquor_id { get; set; }

        public int quantity { get; set; }

        public string type { get; set; }

        public float price { get; set; }

        public string name { get; set; }

        public int supplier_id { get; set; }

        public int clerk_id { get; set; }
    }
}
