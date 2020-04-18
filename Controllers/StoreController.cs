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
    public class StoreController : ControllerBase
    {
        private readonly Context _context;

        public StoreController(Context context)
        {
            _context = context;
        }

        // GET: api/Store/{store_id}/name
        [HttpGet("{input:int}/name")]
        public async Task<IActionResult> GetStoreNameById([FromRoute] int input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _context.StoreName.FromSql("CALL spStoreGetNameById (@id)", new MySqlParameter("@id", input)).ToListAsync();

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }



    }
}