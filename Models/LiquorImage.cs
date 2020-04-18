/**
 * Authors: Gurnoor Aujila, Tyler Lam, Kamalpreet Mundi
 * 
 * This is a model class used to specify what data we really need from the database.
 * In this case the only data we need from the liquor table is the liquor_id and image_link for that specific
 * liquor object in the database
 * **/

using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    // model for liquor product that only has ID and image
    public class LiquorImage
    {
        [Key]
        public int liquor_id { get; set; }

        public string image_link { get; set; }
    }
}
