using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces;

public interface IEntranceRepository
{
    Task<bool> CreateAsync(Entrance entrance);
    Task<Entrance?> GetAsync(Guid id);
    Task<IEnumerable<Entrance>> GetAllAsync();
    Task<bool> UpdateAsync(Entrance entrance);
    Task<bool> DeleteAsync(Guid id);
}
