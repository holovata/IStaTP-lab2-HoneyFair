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
    public class DealersController : ControllerBase
    {
        private readonly HoneyFairContext _context;

        public DealersController(HoneyFairContext context)
        {
            _context = context;
        }

        // GET: api/Dealers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetDealers()
        {
          if (_context.Dealers == null)
          {
              return NotFound();
          }
            return await _context.Dealers.ToListAsync();
        }

        // GET: api/Dealers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> GetDealer(int id)
        {
          if (_context.Dealers == null)
          {
              return NotFound();
          }
            var dealer = await _context.Dealers.FindAsync(id);

            if (dealer == null)
            {
                return NotFound();
            }

            return dealer;
        }

        // PUT: api/Dealers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealer(int id, Dealer dealer)
        {
            if (id != dealer.Id)
            {
                return BadRequest();
            }

            _context.Entry(dealer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerExists(id))
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

        // POST: api/Dealers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dealer>> PostDealer(Dealer dealer)
        {
          if (_context.Dealers == null)
          {
              return Problem("Entity set 'HoneyFairContext.Dealers'  is null.");
          }
            _context.Dealers.Add(dealer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDealer", new { id = dealer.Id }, dealer);
        }

        // DELETE: api/Dealers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealer(int id)
        {
            if (_context.Dealers == null)
            {
                return NotFound();
            }
            var dealer = await _context.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }

            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealerExists(int id)
        {
            return (_context.Dealers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
