using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorVolume
    {
        [Key]
        public int liquor_id { get; set; }

        public int bottle_volume { get; set; }
    }
}
