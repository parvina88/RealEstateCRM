using RealEstate.Domain.Entities;
using RealEstate.Domain.Repositories;

namespace RealEstate.Api.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<bool> CreateAsync(Building building, CancellationToken token = default)
        {
            return await _buildingRepository.CreateAsync(building, token);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Building>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Building?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Building building)
        {
            throw new NotImplementedException();
        }
    }
}
