using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Infrastructure.Repositories;

public class EntranceRepository(IApplicationDbContext context) : IEntranceRepository
{
    private readonly IApplicationDbContext _context = context;

    public async Task<bool> CreateAsync(Entrance entrance, CancellationToken token = default)
    {
        await _context.Entrances.AddAsync(entrance, token);
        var rowAffected = await _context.SaveChangesAsync(token);
        return rowAffected > 0;
    }

    public async Task<IEnumerable<Entrance>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.Entrances.ToListAsync(token);
    }

    public async Task<Entrance> GetAsync(Guid id, CancellationToken token = default)
    {
        return await _context.Entrances.FirstOrDefaultAsync(e => e.Id == id, token);
    }

    public async Task<IEnumerable<Entrance>> GetAllByBuildingAsync(Guid buildingId, CancellationToken token = default)
    {
        return await _context.Entrances.Where(e => e.BuildingId == buildingId).ToListAsync(token);
    }

    public async Task<bool> UpdateAsync(Entrance entrance, CancellationToken token = default)
    {
        _context.Entrances.Update(entrance);
        return await _context.SaveChangesAsync(token) > 0;
    }
    public async Task<bool> DeleteAsync(Entrance entrance, CancellationToken token = default)
    {
        _context.Entrances.Remove(entrance);
        return await _context.SaveChangesAsync(token) > 0;
    }
}
