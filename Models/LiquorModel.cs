using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorModel
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
