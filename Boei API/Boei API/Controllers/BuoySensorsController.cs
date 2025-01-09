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
    public class BuoySensorsController : ControllerBase
    {
        private readonly OracleDbContext _context;

        public BuoySensorsController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: api/BuoySensors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuoySensor>>> GetBuoySensors()
        {
            return await _context.BuoySensors.ToListAsync();
        }

        // GET: api/BuoySensors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuoySensor>> GetBuoySensor(Guid id)
        {
            var buoySensor = await _context.BuoySensors.FindAsync(id);

            if (buoySensor == null)
            {
                return NotFound();
            }

            return buoySensor;
        }

        // PUT: api/BuoySensors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuoySensor(Guid id, BuoySensor buoySensor)
        {
            if (id != buoySensor.ID)
            {
                return BadRequest();
            }

            _context.Entry(buoySensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuoySensorExists(id))
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

        // POST: api/BuoySensors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuoySensor>> PostBuoySensor(BuoySensor buoySensor)
        {
            _context.BuoySensors.Add(buoySensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuoySensor", new { id = buoySensor.ID }, buoySensor);
        }

        // DELETE: api/BuoySensors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuoySensor(Guid id)
        {
            var buoySensor = await _context.BuoySensors.FindAsync(id);
            if (buoySensor == null)
            {
                return NotFound();
            }

            _context.BuoySensors.Remove(buoySensor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuoySensorExists(Guid id)
        {
            return _context.BuoySensors.Any(e => e.ID == id);
        }
    }
}
