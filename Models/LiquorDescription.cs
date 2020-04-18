using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    // model for liquor product that only has ID and description
    public class LiquorDescription
    {
        [Key]
        public int liquor_id { get; set; }

        public string description { get; set; }
    }
}
