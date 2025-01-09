using Boei_API.Core.Repository;
using Boei_API.Services.Repository;

namespace Boei_API.Services.Command
{
    public class BuoyCommandService : IBuoyCommandService
    {
        private readonly IBuoyRepository _repository;

        public BuoyCommandService(IBuoyRepository buoyRepository)
        {
            _repository = buoyRepository;
        }
    }
}
