using Boei_API.Core.Repository;
using Boei_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boei_API.Services.Repository
{
    public class BuoyRepository : IBuoyRepository
    {
        private readonly OracleDbContext _context;

        public BuoyRepository(OracleDbContext context) { }

        public async Task<ActionResult<IEnumerable<Buoy>>> GetBuoys()
        {
            return await _context.Buoys.ToListAsync();
        }

        public async Task<ActionResult<Buoy>> GetBuoy(Guid id)
        {
            var buoy = await _context.Buoys.FindAsync(id);

            if (buoy == null)
            {
                return NotFound();
            }

            return buoy;
        }

        public async Task<IActionResult> PutBuoy(Guid id, Buoy buoy)
        {
            if (id != buoy.ID)
            {
                return BadRequest();
            }

            _context.Entry(buoy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuoyExists(id))
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

        public async Task<ActionResult<Buoy>> PostBuoy(Buoy buoy)
        {
            _context.Buoys.Add(buoy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuoy", new { id = buoy.ID }, buoy);
        }

        public async Task<bool> DeleteBuoy(Guid id)
        {
            var buoy = await _context.Buoys.FindAsync(id);
            if (buoy == null)
            {
                return NotFound();
            }

            _context.Buoys.Remove(buoy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuoyExists(Guid id)
        {
            return _context.Buoys.Any(e => e.ID == id);
        }
    }
}
