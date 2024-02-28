using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces;

public interface IEntranceRepository
{
    Task<bool> CreateAsync(Entrance entrance, CancellationToken token = default);
    Task<Entrance> GetAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<Entrance>> GetAllAsync(CancellationToken token = default);
    Task<IEnumerable<Entrance>> GetAllByBuildingAsync(Guid buildingId, CancellationToken token = default);
    Task<bool> UpdateAsync(Entrance entrance, CancellationToken token = default);
    Task<bool> DeleteAsync(Entrance entrance, CancellationToken token = default);
}
