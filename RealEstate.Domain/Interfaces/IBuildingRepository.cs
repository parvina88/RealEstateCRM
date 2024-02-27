using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces;

public interface IBuildingRepository
{
    Task<bool> CreateAsync(Building building, CancellationToken token = default);
    Task<Building?> GetAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<Building>> GetAllAsync(CancellationToken token = default);
    Task<bool> UpdateAsync(Building building, CancellationToken token = default);
    Task<bool> DeleteAsync(Building building, CancellationToken token = default);
}