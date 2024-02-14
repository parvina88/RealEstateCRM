using RealEstate.Domain.Entities;

namespace RealEstate.Api.Services
{
    public interface IBuildingService
    {
        Task<bool> CreateAsync(Building building, CancellationToken token = default);
        Task<Building?> GetAsync(Guid id);
        Task<IEnumerable<Building>> GetAllAsync();
        Task<bool> UpdateAsync(Building building);
        Task<bool> DeleteAsync(Guid id);
    }
}
