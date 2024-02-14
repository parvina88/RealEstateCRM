using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Repositories;

namespace RealEstate.Infrastructure.Data.Repositories;

public class BuildingRepository : IBuildingRepository
{
    private readonly IApplicationDbContext _context;

    public BuildingRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Building building, CancellationToken token = default)
    {
        await _context.Buildings.AddAsync(building);
        await _context.SaveChangesAsync();
        return true;
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