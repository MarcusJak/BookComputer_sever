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
    public class DatorersController : ControllerBase
    {
        private readonly CONTEXLOCAL _context;

        public DatorersController(CONTEXLOCAL context)
        {
            _context = context;
        }

        // GET: api/Datorers
        [Time]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Datorer>>> GetDatorers()
        {
          if (_context.Datorers == null)
          {
              return NotFound();
          }
            return await _context.Datorers.ToListAsync();
        }

        // GET: api/Datorers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Datorer>> GetDatorer(int id)
        {
          if (_context.Datorers == null)
          {
              return NotFound();
          }
            var datorer = await _context.Datorers.FindAsync(id);

            if (datorer == null)
            {
                return NotFound();
            }

            return datorer;
        }

        // PUT: api/Datorers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatorer(int id, Datorer datorer)
        {
            if (id != datorer.DatorId)
            {
                return BadRequest();
            }

            _context.Entry(datorer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatorerExists(id))
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

        // POST: api/Datorers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Datorer>> PostDatorer(Datorer datorer)
        {
          if (_context.Datorers == null)
          {
              return Problem("Entity set 'CONTEXLOCAL.Datorers'  is null.");
          }
            _context.Datorers.Add(datorer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DatorerExists(datorer.DatorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDatorer", new { id = datorer.DatorId }, datorer);
        }

        // DELETE: api/Datorers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatorer(int id)
        {
            if (_context.Datorers == null)
            {
                return NotFound();
            }
            var datorer = await _context.Datorers.FindAsync(id);
            if (datorer == null)
            {
                return NotFound();
            }

            _context.Datorers.Remove(datorer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatorerExists(int id)
        {
            return (_context.Datorers?.Any(e => e.DatorId == id)).GetValueOrDefault();
        }
    }
}
