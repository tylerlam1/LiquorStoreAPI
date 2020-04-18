/**
 * Authors: Kamalpreet Mundi, Tyler Lam, Gurnoor Aujila
 * 
 * This class is a model class, used to distinguish what data we need from the database. 
 * In This case the data that will be retrieved is the liquor_id and sala_percentage
 * from the liquor_store database. In this case we are accessing the liquor table from the database/
 * 
 * 
 * 
 * 
 * **/


using System.ComponentModel.DataAnnotations;

namespace CPSC471_Proj.Models
{
    public class LiquorSalePercentage
    {
        [Key]
        public int liquor_id { get; set; }

        public float sale_percentage { get; set; }
    }
}
