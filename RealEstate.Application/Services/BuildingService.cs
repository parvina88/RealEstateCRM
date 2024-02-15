using RealEstate.Domain.Entities;
using RealEstate.Domain.Repositories;

namespace RealEstate.Application.Services;

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

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _buildingRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Building>> GetAllAsync()
    {
        return await _buildingRepository.GetAllAsync();
    }

    public async Task<Building?> GetAsync(Guid id)
    {
        return await _buildingRepository.GetAsync(id);
    }

    public async Task<bool> UpdateAsync(Building building)
    {
        return await _buildingRepository.UpdateAsync(building);
    }
}
