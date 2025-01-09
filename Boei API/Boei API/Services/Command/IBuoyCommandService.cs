using Boei_API.Models;

namespace Boei_API.Services.Command
{
    public interface IBuoyCommandService
    {
        Task AddBuoyAsync(Buoy buoy);
        Task<bool> UpdateBuoyAsync(Guid id, Buoy buoy);
    }
}