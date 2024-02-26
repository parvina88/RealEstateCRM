using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Infrastructure.Repositories;

public class BuildingRepository(IApplicationDbContext context) : IBuildingRepository
{
    private readonly IApplicationDbContext _context = context;

    public async Task<bool> CreateAsync(Building building)
    {
        _context.Buildings.Add(building);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Building?> GetAsync(Guid id)
    {
        return await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Building>> GetAllAsync()
    {
        return await _context.Buildings.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Building building)
    {
        _context.Buildings.Update(building);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Building building)
    {
        _context.Buildings.Remove(building);

        return await _context.SaveChangesAsync() > 0;
    }
}