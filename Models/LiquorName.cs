using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    // model for liquor product that only has ID and name
    public class LiquorName
    {
        [Key]
        public int liquor_id { get; set; }

        public string name { get; set; }
    }
}
