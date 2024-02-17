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
    public class DatorHyrningsController : ControllerBase
    {
        private readonly CONTEXLOCAL _context;

        public DatorHyrningsController(CONTEXLOCAL context)
        {
            _context = context;
        }

        // GET: api/DatorHyrnings
        [Time]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatorHyrning>>> GetDatorHyrnings()
        {
          if (_context.DatorHyrnings == null)
          {
              return NotFound();
          }
            return await _context.DatorHyrnings.ToListAsync();
        }

        // GET: api/DatorHyrnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatorHyrning>> GetDatorHyrning(int id)
        {
          if (_context.DatorHyrnings == null)
          {
              return NotFound();
          }
            var datorHyrning = await _context.DatorHyrnings.FindAsync(id);

            if (datorHyrning == null)
            {
                return NotFound();
            }

            return datorHyrning;
        }

        // PUT: api/DatorHyrnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatorHyrning(int id, DatorHyrning datorHyrning)
        {
            if (id != datorHyrning.DatorHyrningId)
            {
                return BadRequest();
            }

            _context.Entry(datorHyrning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatorHyrningExists(id))
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

        // POST: api/DatorHyrnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Time]
        [HttpPost]
        public async Task<ActionResult<DatorHyrning>> PostDatorHyrning(DatorHyrning datorHyrning)
        {
          if (_context.DatorHyrnings == null)
          {
              return Problem("Entity set 'CONTEXLOCAL.DatorHyrnings'  is null.");
          }
            _context.DatorHyrnings.Add(datorHyrning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatorHyrning", new { id = datorHyrning.DatorHyrningId }, datorHyrning);
        }

        // DELETE: api/DatorHyrnings/5
        [Time]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatorHyrning(int id)
        {
            if (_context.DatorHyrnings == null)
            {
                return NotFound();
            }
            var datorHyrning = await _context.DatorHyrnings.FindAsync(id);
            if (datorHyrning == null)
            {
                return NotFound();
            }

            _context.DatorHyrnings.Remove(datorHyrning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatorHyrningExists(int id)
        {
            return (_context.DatorHyrnings?.Any(e => e.DatorHyrningId == id)).GetValueOrDefault();
        }
    }
}
