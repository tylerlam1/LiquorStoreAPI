/**
 * Authors: Gurnoor Aujila, Kamalpreet Mundi, Tyler Lam
 * 
 * This class is a model class used to filter what kinda of data we really need.
 * In this case we are accessing data from the liquor_store database.
 * And are accessing the Store table. From this table the data we really want
 * according to this model is the store_id and its corressponding name.
 * 
 * 
 * 
 * **/



using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class StoreName
    {
        [Key]
        public int store_id { get; set; }

        public string name { get; set; }
    }
}
