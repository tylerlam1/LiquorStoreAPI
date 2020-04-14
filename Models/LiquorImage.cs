using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorImage
    {
        [Key]
        public int liquor_id { get; set; }

        public string image_link { get; set; }
    }
}
