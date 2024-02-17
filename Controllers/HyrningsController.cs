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
    public class HyrningsController : ControllerBase
    {
        private readonly CONTEXLOCAL _context;

        public HyrningsController(CONTEXLOCAL context)
        {
            _context = context;
        }

        // GET: api/Hyrnings
        [Time]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hyrning>>> GetHyrnings()
        {
          if (_context.Hyrnings == null)
          {
              return NotFound();
          }
            return await _context.Hyrnings.ToListAsync();
        }

        // GET: api/Hyrnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hyrning>> GetHyrning(int id)
        {
          if (_context.Hyrnings == null)
          {
              return NotFound();
          }
            var hyrning = await _context.Hyrnings.FindAsync(id);

            if (hyrning == null)
            {
                return NotFound();
            }

            return hyrning;
        }

        // PUT: api/Hyrnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHyrning(int id, Hyrning hyrning)
        {
            if (id != hyrning.HyrningsId)
            {
                return BadRequest();
            }

            _context.Entry(hyrning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HyrningExists(id))
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

        // POST: api/Hyrnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Time]
        [HttpPost]
        public async Task<ActionResult<Hyrning>> PostHyrning(Hyrning hyrning)
        {
          if (_context.Hyrnings == null)
          {
              return Problem("Entity set 'CONTEXLOCAL.Hyrnings'  is null.");
          }
            _context.Hyrnings.Add(hyrning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHyrning", new { id = hyrning.HyrningsId }, hyrning);
        }

        // DELETE: api/Hyrnings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHyrning(int id)
        {
            if (_context.Hyrnings == null)
            {
                return NotFound();
            }
            var hyrning = await _context.Hyrnings.FindAsync(id);
            if (hyrning == null)
            {
                return NotFound();
            }

            _context.Hyrnings.Remove(hyrning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HyrningExists(int id)
        {
            return (_context.Hyrnings?.Any(e => e.HyrningsId == id)).GetValueOrDefault();
        }
    }
}
