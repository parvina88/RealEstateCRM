using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces;

public interface IEntranceRepository
{
    Task<bool> CreateAsync(Entrance entrance);
    Task<Entrance> GetAsync(Guid id);
    Task<IEnumerable<Entrance>> GetAllAsync();
    Task<IEnumerable<Entrance>> GetAllByBuildingAsync();
    Task<bool> UpdateAsync(Entrance entrance);
    Task<bool> DeleteAsync(Entrance entrance);
}
