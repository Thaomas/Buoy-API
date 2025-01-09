using Boei_API.Core.Repository;

namespace Boei_API.Services.Query
{
    public class BuoyQueryService : IBuoyQueryService
    {
        private readonly IBuoyRepository _repository;

        public BuoyQueryService(IBuoyRepository repository)
        {
            _repository = repository;

        }
    }
}
