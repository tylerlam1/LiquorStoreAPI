/**
 * Authors: Gurnoor Aujila, Tyler Lam, Kamalpreet Mundi 
 * 
 * This is a model class used to kind of filter what type of data we really need from the database.
 * In this case the database we are accessing is the liquor_store database.
 * Accessing the specific table, Liquors.
 * Here we want the liquor_id and the bottle_volume of a specific liquor.
 * 
 * 
 * **/

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
