/**
 * Authors: Gurnoor Aujila, Tyler Lam, Kamalpreet Mundi
 * 
 * This class is a controller class used to access and return data from the database.
 * In this case our database is the liquor_store database.
 * This controller in particular is only responsible for a specific table.
 * In this case that table is the liquor table from the database.
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
        // Get all information from all liquor products
        [HttpGet("all")]
        public IEnumerable<Liquor> GetLiquor()
        {
            return _context.Liquor.FromSql("spLiquorGetAll").ToList();
        }

        // GET: api/Liquors/sale
        // Get all information from all liquor products that are on sale (where sale length and sale percentage are greater than 0)
        [HttpGet("sale")]
        public IEnumerable<Liquor> GetLiquorOnSale()
        {
            return _context.Liquor.FromSql("spLiquorGetAllSale").ToList();
        }

        // GET: api/Liquors/{liquor_id}/name
        // Get the liquor name from a liquor product using liquor ID
        [HttpGet("{input:int}/name")]
        public async Task<IActionResult> GetLiquorNameById([FromRoute] int input)
        {
            // checks if the database can be reached
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorName.FromSql("CALL spLiquorGetNameById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            // checks if there was a return. If not, return a 404
            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // GET: api/Liquors/{liquor_id}/description
        // Get the liquor description from a liquor product using liquor ID
        [HttpGet("{input:int}/description")]
        public async Task<IActionResult> GetLiquorDescriptionById([FromRoute] int input)
        {
            // checks if the database can be reached
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorDescription.FromSql("CALL spLiquorGetDescriptionById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            // checks if there was a return. If not, return a 404
            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // GET: api/Liquors/{liquor_id}/image
        // Get the liquor image link from a liquor product using liquor ID
        [HttpGet("{input:int}/image")]
        public async Task<IActionResult> GetLiquorImageById([FromRoute] int input)
        {
            // checks if the database can be reached
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorImage.FromSql("CALL spLiquorGetImageById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            // checks if there was a return. If not, return a 404
            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }


        // ADDED:
        // GET: api/Liquors/{liquor_id}/price
        [HttpGet("{input:int}/price")]
        public async Task<IActionResult> GetLiquorPriceById([FromRoute] int input){
        
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorPrice.FromSql("CALL spLiquorGetPriceById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // ADDED:
        // GET: api/Liquors/{liquor_id}/sale_percentage
        [HttpGet("{input:int}/sale_percentage")]
        public async Task<IActionResult> GetLiquorSalePercentageById([FromRoute] int input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorSalePercentage.FromSql("CALL spLiquorGetSalePercentageById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // GET: api/Liquors/{liquor_id}/sale_length
        [HttpGet("{input:int}/sale_length")]
        public async Task<IActionResult> GetLiquorSaleLengthById([FromRoute] int input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorSaleLength.FromSql("CALL spLiquorGetSaleLengthById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);

        }

        // Get: api/Liquors/{liquor_id}/quantity
        [HttpGet("{input:int}/quantity")]
        public async Task<IActionResult> GetLiquorQuantityById([FromRoute] int input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorQuantity.FromSql("CALL spLiquorGetQuantityById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // Get: api/Liquors/{liquor_id}/volume
        [HttpGet("{input:int}/volume")]
        public async Task<IActionResult> GetLiquorVolumeById([FromRoute] int input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.LiquorVolume.FromSql("CALL spLiquorGetVolumeById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // PUT: api/Liquors/image
        [HttpPut("image")]
        public async Task<IActionResult> PutLiquorImageById([FromBody] Liquor liquor_body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MySqlParameter image_link = new MySqlParameter("@link", liquor_body.image_link);
            MySqlParameter liquor_id = new MySqlParameter("@id", liquor_body.liquor_id);

            var value = await _context.Database.ExecuteSqlCommandAsync("CALL spLiquorPutImageLinkByID (@id, " +
                  "@link)", liquor_id, image_link);

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
            MySqlParameter sale_length = new MySqlParameter("@sale_length", liquor_body.sale_length);

             var value = await _context.Database.ExecuteSqlCommandAsync("CALL spLiquorPost (@id, " +
                "@name, @type, @price, @quantity, @description, @supplier_id, @clerk_id, " +
                "@image_link, @bottle_volume, @sale_percentage, @sale_length)", id, name, 
                type, price, quantity, description, supplier_id, clerk_id, image_link,
                bottle_volume, sale_percentage, sale_length);

            return getPostAndPutStatus(value);
        }

        public IActionResult getPostAndPutStatus(int value)
        {
            if (value == 1)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}