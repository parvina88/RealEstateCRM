using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Infrastructure.Repositories;

public class BuildingRepository : IBuildingRepository
{
    private readonly IApplicationDbContext _context;

    public BuildingRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Building building, CancellationToken token = default)
    {
        _context.Buildings.Add(building);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<Building?> GetAsync(Guid id)
    {
        return await _context.Buildings.FindAsync(id);
    }

    public async Task<IEnumerable<Building>> GetAllAsync()
    {
        return await _context.Buildings.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Building building)
    {
        _context.Buildings.Update(building);
        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var buildingToDelete = await GetAsync(id);

        if (buildingToDelete == null)
            return false;

        _context.Buildings.Remove(buildingToDelete);

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;


    }
}