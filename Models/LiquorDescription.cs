/**
 * Authors: Kamalpreet Mundi, Gurnoor Aujila, Tyler Lam
 * 
 * This class is a model class used to filter data being returned from the database (liquor_store).
 * In this case we are only returning the liquor_id and the description for that liquor_id
 *  for a specific liquor object in the database.
 * 
 * **/

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
