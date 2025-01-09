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
    public class SensorTypesController : ControllerBase
    {
        private readonly OracleDbContext _context;

        public SensorTypesController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: api/SensorTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorType>>> GetSensorTypes()
        {
            return await _context.SensorTypes.ToListAsync();
        }

        // GET: api/SensorTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorType>> GetSensorType(Guid id)
        {
            var sensorType = await _context.SensorTypes.FindAsync(id);

            if (sensorType == null)
            {
                return NotFound();
            }

            return sensorType;
        }

        // PUT: api/SensorTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorType(Guid id, SensorType sensorType)
        {
            if (id != sensorType.ID)
            {
                return BadRequest();
            }

            _context.Entry(sensorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorTypeExists(id))
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

        // POST: api/SensorTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SensorType>> PostSensorType(SensorType sensorType)
        {
            _context.SensorTypes.Add(sensorType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorType", new { id = sensorType.ID }, sensorType);
        }

        // DELETE: api/SensorTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorType(Guid id)
        {
            var sensorType = await _context.SensorTypes.FindAsync(id);
            if (sensorType == null)
            {
                return NotFound();
            }

            _context.SensorTypes.Remove(sensorType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensorTypeExists(Guid id)
        {
            return _context.SensorTypes.Any(e => e.ID == id);
        }
    }
}
