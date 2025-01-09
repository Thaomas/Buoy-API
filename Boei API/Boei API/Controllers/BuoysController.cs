using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Boei_API.Models;
using Boei_API.Services.Command;
using Boei_API.Services.Query;

namespace Boei_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuoysController : ControllerBase
    {
        private readonly IBuoyCommandService _commandService;
        private readonly IBuoyQueryService _queryService;

        public BuoysController(IBuoyCommandService commandService, IBuoyQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // GET: api/Buoys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buoy>>> GetBuoys()
        {
            return await _queryService.GetAllBuoysAysnc();
        }

        // GET: api/Buoys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buoy>> GetBuoy(Guid id)
        {
            var buoy = await _queryService.GetBuoyByIdAsync(id);

            if (buoy == null)
            {
                return NotFound();
            }

            return buoy;
        }

        // PUT: api/Buoys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuoy(Guid id, Buoy buoy)
        {
            if (id != buoy.ID)
            {
                return BadRequest();
            }

            try
            {
                bool status = await _commandService.UpdateBuoyAsync(id, buoy);
                if (!status)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Buoys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buoy>> PostBuoy(Buoy buoy)
        {
            await _commandService.AddBuoyAsync(buoy);

            return CreatedAtAction("GetBuoy", new { id = buoy.ID }, buoy);
        }

        // DELETE: api/Buoys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuoy(Guid id)
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

    }
}
