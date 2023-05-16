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
    public class FairLocationsController : ControllerBase
    {
        private readonly HoneyFairContext _context;

        public FairLocationsController(HoneyFairContext context)
        {
            _context = context;
        }

        // GET: api/FairLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FairLocation>>> GetFairLocations()
        {
          if (_context.FairLocations == null)
          {
              return NotFound();
          }
            return await _context.FairLocations.ToListAsync();
        }

        // GET: api/FairLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FairLocation>> GetFairLocation(int id)
        {
          if (_context.FairLocations == null)
          {
              return NotFound();
          }
            var fairLocation = await _context.FairLocations.FindAsync(id);

            if (fairLocation == null)
            {
                return NotFound();
            }

            return fairLocation;
        }

        // PUT: api/FairLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFairLocation(int id, FairLocation fairLocation)
        {
            if (id != fairLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(fairLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FairLocationExists(id))
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

        // POST: api/FairLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FairLocation>> PostFairLocation(FairLocation fairLocation)
        {
          if (_context.FairLocations == null)
          {
              return Problem("Entity set 'HoneyFairContext.FairLocations'  is null.");
          }
            _context.FairLocations.Add(fairLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFairLocation", new { id = fairLocation.Id }, fairLocation);
        }

        // DELETE: api/FairLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFairLocation(int id)
        {
            if (_context.FairLocations == null)
            {
                return NotFound();
            }
            var fairLocation = await _context.FairLocations.FindAsync(id);
            if (fairLocation == null)
            {
                return NotFound();
            }

            _context.FairLocations.Remove(fairLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FairLocationExists(int id)
        {
            return (_context.FairLocations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
