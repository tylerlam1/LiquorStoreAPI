/**
 * Authors: Tyler Lam, Kamalpreet Mundi, Gurnoor Aujila
 * 
 * This class is a model class to specify what type of data we want to return from the database.
 * In this case we want to return the liquor_id and sale_length for a liquor product from the database.
 * 
 * 
 * 
 * 
 * 
 * **/

using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorSaleLength
    {
        [Key]
        public int liquor_id { get; set; }

        public int sale_length { get; set; }
    }
}