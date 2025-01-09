using Boei_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boei_API.Services.Query
{
    public interface IBuoyQueryService
    {
        Task<ActionResult<Buoy>> GetBuoyByIdAsync(Guid id);
        Task<ActionResult<IEnumerable<Buoy>>> GetAllBuoysAysnc();
        bool BuoyExists(Guid id);
    }
}