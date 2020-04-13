﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPSC471_Proj.Models;

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
        [HttpGet]
        public IEnumerable<Liquor> GetLiquor()
        {
            return _context.Liquor;
        }

        // GET: api/Liquors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLiquor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.Liquor.FindAsync(id);

            if (liquor == null)
            {
                return NotFound();
            }

            return Ok(liquor);
        }

        // PUT: api/Liquors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiquor([FromRoute] int id, [FromBody] Liquor liquor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != liquor.liquor_id)
            {
                return BadRequest();
            }

            _context.Entry(liquor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiquorExists(id))
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

        // POST: api/Liquors
        [HttpPost]
        public async Task<IActionResult> PostLiquor([FromBody] Liquor liquor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Liquor.Add(liquor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiquor", new { id = liquor.liquor_id }, liquor);
        }

        // DELETE: api/Liquors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiquor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var liquor = await _context.Liquor.FindAsync(id);
            if (liquor == null)
            {
                return NotFound();
            }

            _context.Liquor.Remove(liquor);
            await _context.SaveChangesAsync();

            return Ok(liquor);
        }

        private bool LiquorExists(int id)
        {
            return _context.Liquor.Any(e => e.liquor_id == id);
        }
    }
}