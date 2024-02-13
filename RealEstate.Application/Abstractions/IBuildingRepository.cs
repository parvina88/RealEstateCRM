using RealEstate.Domain.Entities;

namespace RealEstate.Application.Abstractions;

public interface IBuildingRepository
{
    Task<bool> CreateAsync(Building building);
    Task<Building?> GetAsync(Guid id);
    Task<IEnumerable<Building>> GetAllAsync();
    Task<bool> UpdateAsync(Building building);
    Task<bool> DeleteAsync(Guid id);
}