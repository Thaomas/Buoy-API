using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Boei_API;
using Boei_API.Models;

namespace Boei_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPSLocationsController : ControllerBase
    {
        private readonly OracleDbContext _context;

        public GPSLocationsController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: api/GPSLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GPSLocation>>> GetGPSLocations()
        {
            return await _context.GPSLocations.ToListAsync();
        }

        // GET: api/GPSLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GPSLocation>> GetGPSLocation(Guid id)
        {
            var gPSLocation = await _context.GPSLocations.FindAsync(id);

            if (gPSLocation == null)
            {
                return NotFound();
            }

            return gPSLocation;
        }

        // PUT: api/GPSLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGPSLocation(Guid id, GPSLocation gPSLocation)
        {
            if (id != gPSLocation.ID)
            {
                return BadRequest();
            }

            _context.Entry(gPSLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPSLocationExists(id))
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

        // POST: api/GPSLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GPSLocation>> PostGPSLocation(GPSLocation gPSLocation)
        {
            _context.GPSLocations.Add(gPSLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGPSLocation", new { id = gPSLocation.ID }, gPSLocation);
        }

        // DELETE: api/GPSLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGPSLocation(Guid id)
        {
            var gPSLocation = await _context.GPSLocations.FindAsync(id);
            if (gPSLocation == null)
            {
                return NotFound();
            }

            _context.GPSLocations.Remove(gPSLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GPSLocationExists(Guid id)
        {
            return _context.GPSLocations.Any(e => e.ID == id);
        }
    }
}
