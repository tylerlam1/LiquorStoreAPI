using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPSC471_Proj.Models;

namespace CPSC471_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquorModelsController : ControllerBase
    {
        private readonly Context _context;

        public LiquorModelsController(Context context)
        {
            _context = context;
        }

        // GET: api/LiquorModels
        [HttpGet]
        public IEnumerable<LiquorModel> GetLiquorModels()
        {
            return _context.LiquorModels;
        }

        // GET: api/LiquorModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLiquorModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquorModel = await _context.LiquorModels.FindAsync(id);

            if (liquorModel == null)
            {
                return NotFound();
            }

            return Ok(liquorModel);
        }

        // PUT: api/LiquorModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiquorModel([FromRoute] int id, [FromBody] LiquorModel liquorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != liquorModel.liquor_id)
            {
                return BadRequest();
            }

            _context.Entry(liquorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiquorModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LiquorModels
        [HttpPost]
        public async Task<IActionResult> PostLiquorModel([FromBody] LiquorModel liquorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LiquorModels.Add(liquorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(liquorModel), new { id = liquorModel.liquor_id }, liquorModel);
        }

        // DELETE: api/LiquorModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiquorModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquorModel = await _context.LiquorModels.FindAsync(id);
            if (liquorModel == null)
            {
                return NotFound();
            }

            _context.LiquorModels.Remove(liquorModel);
            await _context.SaveChangesAsync();

            return Ok(liquorModel);
        }

        private bool LiquorModelExists(int id)
        {
            return _context.LiquorModels.Any(e => e.liquor_id == id);
        }
    }
}