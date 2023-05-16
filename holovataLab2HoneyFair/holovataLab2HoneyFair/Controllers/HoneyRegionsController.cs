using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using holovataLab2HoneyFair.Models;

namespace holovataLab2HoneyFair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoneyRegionsController : ControllerBase
    {
        private readonly HoneyFairContext _context;

        public HoneyRegionsController(HoneyFairContext context)
        {
            _context = context;
        }

        // GET: api/HoneyRegions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoneyRegion>>> GetHoneyRegions()
        {
          if (_context.HoneyRegions == null)
          {
              return NotFound();
          }
            return await _context.HoneyRegions.ToListAsync();
        }

        // GET: api/HoneyRegions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoneyRegion>> GetHoneyRegion(int id)
        {
          if (_context.HoneyRegions == null)
          {
              return NotFound();
          }
            var honeyRegion = await _context.HoneyRegions.FindAsync(id);

            if (honeyRegion == null)
            {
                return NotFound();
            }

            return honeyRegion;
        }

        // PUT: api/HoneyRegions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoneyRegion(int id, HoneyRegion honeyRegion)
        {
            if (id != honeyRegion.Id)
            {
                return BadRequest();
            }

            _context.Entry(honeyRegion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoneyRegionExists(id))
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

        // POST: api/HoneyRegions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoneyRegion>> PostHoneyRegion(HoneyRegion honeyRegion)
        {
          if (_context.HoneyRegions == null)
          {
              return Problem("Entity set 'HoneyFairContext.HoneyRegions'  is null.");
          }
            _context.HoneyRegions.Add(honeyRegion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoneyRegion", new { id = honeyRegion.Id }, honeyRegion);
        }

        // DELETE: api/HoneyRegions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoneyRegion(int id)
        {
            if (_context.HoneyRegions == null)
            {
                return NotFound();
            }
            var honeyRegion = await _context.HoneyRegions.FindAsync(id);
            if (honeyRegion == null)
            {
                return NotFound();
            }

            _context.HoneyRegions.Remove(honeyRegion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoneyRegionExists(int id)
        {
            return (_context.HoneyRegions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
