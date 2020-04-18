using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPSC471_Proj.Models;
using MySql.Data.MySqlClient;

namespace CPSC471_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquorsController : ControllerBase
    {
        private readonly Context _context;

        public LiquorsController(Context context)
        {
            _context = context;
        }

        // GET: api/Liquors
        [HttpGet("all")]
        public IEnumerable<Liquor> GetLiquor()
        {
            return _context.Liquor.FromSql("spLiquorGetAll").ToList();
        }

        // GET: api/Liquors/sale
        [HttpGet("sale")]
        public IEnumerable<Liquor> GetLiquorOnSale()
        {
            return _context.Liquor.FromSql("spLiquorGetAllSale").ToList();
        }

        // GET: api/Liquors/{liquor_id}/name
        [HttpGet("{input:int}/name")]
        public async Task<IActionResult> GetLiquorNameById([FromRoute] int input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorName.FromSql("CALL spLiquorGetNameById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // GET: api/Liquors/{liquor_id}/description
        [HttpGet("{input:int}/description")]
        public async Task<IActionResult> GetLiquorDescriptionById([FromRoute] int input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorDescription.FromSql("CALL spLiquorGetDescriptionById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // GET: api/Liquors/{liquor_id}/image
        [HttpGet("{input:int}/image")]                  
        public async Task<IActionResult> GetLiquorImageById([FromRoute] int input) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);                  
            }

            var liquor = await _context.LiquorImage.FromSql("CALL spLiquorGetImageById (@id)", new MySqlParameter("@id", input)).ToListAsync(); 

            if (liquor == null) 
            {
                return NotFound();
            }

            return Ok(liquor); 
        }


        // ADDED:
        // GET: api/Liquors/{liquor_id}/price   // Get request URL, input is an integer
        [HttpGet("{input:int}/price")]
        public async Task<IActionResult> GetLiquorPriceById([FromRoute] int input){    //get an int input from the URL
        
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);                                       //If model state is invalid return a Bad request
            }

            var liquor = await _context.LiquorPrice.FromSql("CALL spLiquorGetPriceById (@id)", new MySqlParameter("@id", input)).ToListAsync();  //Call stored procdeure to get Liquor with input as SQL parameter ID
             
            if (liquor == null)   // if liqour object null return not found
            {
                return NotFound();
            }

            return Ok(liquor);   // status 200
        }

        // ADDED:
        // GET: api/Liquors/{liquor_id}/sale_percentage
        [HttpGet("{input:int}/sale_percentage")] // URL input is an integer for the id
        public async Task<IActionResult> GetLiquorSalePercentageById([FromRoute] int input) //Routed input from the URL
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  //If there is a bad model state return bad request
            }

            var liquor = await _context.LiquorSalePercentage.FromSql("CALL spLiquorGetSalePercentageById (@id)", new MySqlParameter("@id", input)).ToListAsync();  //Using id sql parameter, get liquor sale percentage

            if (liquor == null)  //no liquor object found return null
            {
                return NotFound();
            }

            return Ok(liquor); //status 200
        }

        // GET: api/Liquors/{liquor_id}/sale_length
        [HttpGet("{input:int}/sale_length")]  // URL input is an integer for the id
        public async Task<IActionResult> GetLiquorSaleLengthById([FromRoute] int input) // integer input for int
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);   //If there is a bad model state return bad request
            }

            var liquor = await _context.LiquorSaleLength.FromSql("CALL spLiquorGetSaleLengthById (@id)", new MySqlParameter("@id", input)).ToListAsync(); //Using id sql parameter, get liquor sale length

            if (liquor == null)
            {
                return NotFound();         // if no liquor object return null
            }

            return Ok(liquor);                // Return status 200 

        }

        // Get: api/Liquors/{liquor_id}/quantity
        [HttpGet("{input:int}/quantity")]          //URL input is an integer for the ID 
        public async Task<IActionResult> GetLiquorQuantityById([FromRoute] int input)      //integer input for int
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);        //if model state is invalid
            }

            var liquor = await _context.LiquorQuantity.FromSql("CALL spLiquorGetQuantityById (@id)", new MySqlParameter("@id", input)).ToListAsync(); //Using ID SQL parameter use stored procedure to get liquor quantity

            if (liquor == null)   //Liquor object is null return not found
            {
                return NotFound();
            }

            return Ok(liquor);    //return status 200 
        }

        // Get: api/Liquors/{liquor_id}/volume
        [HttpGet("{input:int}/volume")]            //URL input is an integer for the ID 
        public async Task<IActionResult> GetLiquorVolumeById([FromRoute] int input)  //integer input for int
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);        //if model state is invalid
            }

            var liquor = await _context.LiquorVolume.FromSql("CALL spLiquorGetVolumeById (@id)", new MySqlParameter("@id", input)).ToListAsync();  //Using ID SQL parameter use stored procedure to get liquor quantity

            if (liquor == null)    //Liquor object is null return not found
            {
                return NotFound();
            }

            return Ok(liquor);    //return status 200 
        }

        // PUT: api/Liquors/image
        [HttpPut("image")]  // PUT request for image
        public async Task<IActionResult> PutLiquorImageById([FromBody] Liquor liquor_body) //Get the parameters for the Stored procedures from the body
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);   //invalid model return bad request 
            }

            MySqlParameter image_link = new MySqlParameter("@link", liquor_body.image_link);         //image link is equivalent to image link from object
            MySqlParameter liquor_id = new MySqlParameter("@id", liquor_body.liquor_id);             // id is equivalent to liquor_id from object

            var value = await _context.Database.ExecuteSqlCommandAsync("CALL spLiquorPutImageLinkByID (@id, " +
                  "@link)", liquor_id, image_link);                                                  //use the id and link to do a stored procdeure from SQL.

            return getPostAndPutStatus(value);                                                       
        }

        // POST: api/Liquors
        [HttpPost]
        public async Task<IActionResult> PostLiquor([FromBody] Liquor liquor_body) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MySqlParameter id = new MySqlParameter("@id", liquor_body.liquor_id);
            MySqlParameter name = new MySqlParameter("@name", liquor_body.name);
            MySqlParameter type = new MySqlParameter("@type", liquor_body.type);
            MySqlParameter price = new MySqlParameter("@price", liquor_body.price);
            MySqlParameter quantity = new MySqlParameter("@quantity", liquor_body.price);
            MySqlParameter description = new MySqlParameter("@description", liquor_body.description);
            MySqlParameter supplier_id = new MySqlParameter("@supplier_id", liquor_body.supplier_id);
            MySqlParameter clerk_id = new MySqlParameter("@clerk_id", liquor_body.clerk_id);
            MySqlParameter image_link = new MySqlParameter("@image_link", liquor_body.image_link);
            MySqlParameter bottle_volume = new MySqlParameter("@bottle_volume", liquor_body.bottle_volume);
            MySqlParameter sale_percentage = new MySqlParameter("@sale_percentage", liquor_body.sale_percentage);
            MySqlParameter sale_length = new MySqlParameter("@sale_length", liquor_body.sale_length);     //CREATE OBJECT WITH ALL LIQUOR PARAMETERS

             var value = await _context.Database.ExecuteSqlCommandAsync("CALL spLiquorPost (@id, " +
                "@name, @type, @price, @quantity, @description, @supplier_id, @clerk_id, " +
                "@image_link, @bottle_volume, @sale_percentage, @sale_length)", id, name, 
                type, price, quantity, description, supplier_id, clerk_id, image_link,
                bottle_volume, sale_percentage, sale_length);          //Add the value of the object to SQL with stored procedure. 

            return getPostAndPutStatus(value);
        }

        public IActionResult getPostAndPutStatus(int value)
        {
            if (value == 1)
            {
                return Ok();              //used to give  a status 200 for post and put functions. 
            }

            return NotFound();
        }
    }
}