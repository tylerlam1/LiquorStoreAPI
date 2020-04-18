/**
 * Authors: Tyler Lam, Gurnoor Aujila, Kamalpreet Mundi
 * 
 * This controller class is used to access data from our database(liquor_store database).
 * Specifically it is used to access the store table.
 * Retriving specific data from the table, and displaying the output on the website.
 * 
 * Other classes used in conjunction with this include 
 * Context.cs
 * StoreName.cs
 * 
 * 
 * **/

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPSC471_Proj.Models;
using MySql.Data.MySqlClient;
namespace CPSC471_Proj.Controllers
{
    // Setting up the route
    // api/Store/...
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase   // The actual controller fucntion
    {
        private readonly Context _context;      // Initalizing variable from Context class Which decides what model class to call(other than context.cs)

        public StoreController(Context context) // Constructor
        {
            _context = context;
        }

        // GET: api/Store/{store_id}/name
        // This function gets the name of the store, according to the input ID provided from the API route
        // If a valid id is inputted, the name of the store and the store id will be displayed
        [HttpGet("{input:int}/name")]
        public async Task<IActionResult> GetStoreNameById([FromRoute] int input)
        {
            if (!ModelState.IsValid)    // If any problem occurs  
            {
                return BadRequest(ModelState);      // Return a bad request
            }

            // Get the information from the database, calling the store procedure spStoreGetNameById
            // Providing the integer input 
            var store = await _context.StoreName.FromSql("CALL spStoreGetNameById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (store == null)  // If null is returned(could not find in database)
            {
                return NotFound();  // Simply return notFound
            }

            return Ok(store);   // Otherwise if something was found, return that variable
        }



    }
}