using RealEstate.Application.Abstractions;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Repositories;

public class BuildingRepository : IBuildingRepository
{
    public Task<bool> CreateAsync(Building building)
    {
        throw new NotImplementedException();
    }

    public Task<Building?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Building>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Building building)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}