using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorDescription
    {
        [Key]
        public int liquor_id { get; set; }

        public string description { get; set; }
    }
}
