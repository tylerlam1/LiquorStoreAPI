/**
 * Authors: Kamalpreet Mundi, Tyler Lam, Gurnoor Aujila
 * 
 * This class is simply used to specify what data is relevant to be returned.
 * In this case the relevant data we need is the quantity of liquor(amount of liquor in stock)
 * 
 * 
 * 
 * 
 * **/
using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models   
{
    public class LiquorQuantity // The class name itself
    {
        [Key]
        public int liquor_id { get; set; }  // liquor_id,

        public int quantity { get; set; }   // quantity
    }
}