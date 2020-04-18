/**
 * Authors: Tyler Lam, Kamalpreet Mundi, Gurnoor Aujila
 * 
 * This is a model class, used to kind of filter the data we need from the database.
 * In this case, as noted from the name of this class. 
 * What will be stored is the liquor_id and the name of that specific liquor_id.
 * 
 * **/
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
