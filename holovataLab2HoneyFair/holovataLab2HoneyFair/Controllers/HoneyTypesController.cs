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
    public class HoneyTypesController : ControllerBase
    {
        private readonly HoneyFairContext _context;

        public HoneyTypesController(HoneyFairContext context)
        {
            _context = context;
        }

        // GET: api/HoneyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoneyType>>> GetHoneyTypes()
        {
          if (_context.HoneyTypes == null)
          {
              return NotFound();
          }
            return await _context.HoneyTypes.ToListAsync();
        }

        // GET: api/HoneyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoneyType>> GetHoneyType(int id)
        {
          if (_context.HoneyTypes == null)
          {
              return NotFound();
          }
            var honeyType = await _context.HoneyTypes.FindAsync(id);

            if (honeyType == null)
            {
                return NotFound();
            }

            return honeyType;
        }

        // PUT: api/HoneyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoneyType(int id, HoneyType honeyType)
        {
            if (id != honeyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(honeyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoneyTypeExists(id))
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

        // POST: api/HoneyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoneyType>> PostHoneyType(HoneyType honeyType)
        {
          if (_context.HoneyTypes == null)
          {
              return Problem("Entity set 'HoneyFairContext.HoneyTypes'  is null.");
          }
            _context.HoneyTypes.Add(honeyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoneyType", new { id = honeyType.Id }, honeyType);
        }

        // DELETE: api/HoneyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoneyType(int id)
        {
            if (_context.HoneyTypes == null)
            {
                return NotFound();
            }
            var honeyType = await _context.HoneyTypes.FindAsync(id);
            if (honeyType == null)
            {
                return NotFound();
            }

            _context.HoneyTypes.Remove(honeyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoneyTypeExists(int id)
        {
            return (_context.HoneyTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
