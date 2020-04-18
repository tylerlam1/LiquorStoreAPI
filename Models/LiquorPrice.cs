/**
 * Authors: Tyler Lam, Gurnoor Aujila, Kamalpreet Mundi
 * 
 * This is a model class used to kind of filter the data we really need.
 * In this case all we need is the liquor_id and the price for the corresponding liquor_id
 * from the database. In this case this data is coming for the liquor table.
 * 
 * **/


using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorPrice
    {
        [Key]
        public int liquor_id { get; set; }

        public double price { get; set; }
    }
}