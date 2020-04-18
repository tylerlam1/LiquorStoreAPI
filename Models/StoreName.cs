using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class StoreName
    {
        [Key]
        public int store_id { get; set; }

        public string name { get; set; }
    }
}
