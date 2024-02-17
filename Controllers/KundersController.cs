using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MethodTimer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Model;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundersController : ControllerBase
    {
        private readonly CONTEXLOCAL _context;

        public KundersController(CONTEXLOCAL context)
        {
            _context = context;
        }

        // GET: api/Kunders
        [Time]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunder>>> GetKunder([FromQuery] int userId = 0, [FromQuery] string password = "")
        {
            // Om userId inte anges, returnera alla kunder
            if (userId == 0)
            {
                return await _context.Kunders.ToListAsync();
            }

            // Annars, sök i databasen med användar-ID och lösenord
            var kunder = await _context.Kunders.Where(k => k.KundId == userId && k.Lösenord == password).ToListAsync();

            if (kunder == null || !kunder.Any())
            {
                return NotFound();
            }

            return kunder;
        }


        // GET: api/Kunders/5
        [Time]
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunder>> GetKunder(int id)
        {
          if (_context.Kunders == null)
          {
              return NotFound();
          }
            var kunder = await _context.Kunders.FindAsync(id);

            if (kunder == null)
            {
                return NotFound();
            }

            return kunder;
        }

        // PUT: api/Kunders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKunder(int id, Kunder kunder)
        {
            if (id != kunder.KundId)
            {
                return BadRequest();
            }

            _context.Entry(kunder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KunderExists(id))
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

        // POST: api/Kunders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kunder>> PostKunder(Kunder kunder)
        {
          if (_context.Kunders == null)
          {
              return Problem("Entity set 'CONTEXLOCAL.Kunders'  is null.");
          }
            _context.Kunders.Add(kunder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KunderExists(kunder.KundId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKunder", new { id = kunder.KundId }, kunder);
        }

        // DELETE: api/Kunders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKunder(int id)
        {
            if (_context.Kunders == null)
            {
                return NotFound();
            }
            var kunder = await _context.Kunders.FindAsync(id);
            if (kunder == null)
            {
                return NotFound();
            }

            _context.Kunders.Remove(kunder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KunderExists(int id)
        {
            return (_context.Kunders?.Any(e => e.KundId == id)).GetValueOrDefault();
        }
    }
}
