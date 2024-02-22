using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Infrastructure.Repositories;

public class EntranceRepository(IApplicationDbContext context) : IEntranceRepository
{
    private readonly IApplicationDbContext _context = context;

    public async Task<bool> CreateAsync(Entrance entrance)
    {
        _context.Entrances.Add(entrance);
        var rowAffected = await _context.SaveChangesAsync();
        return rowAffected > 0;
    }

    public async Task<IEnumerable<Entrance>> GetAllAsync()
    {
        return await _context.Entrances.ToListAsync();
    }

    public async Task<Entrance> GetAsync(Guid id)
    {
        return await _context.Entrances.FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task<IEnumerable<Entrance>> GetAllByBuildingAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Entrance entrance)
    {
        _context.Entrances.Update(entrance);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteAsync(Entrance entrance)
    {
        _context.Entrances.Remove(entrance);
        return await _context.SaveChangesAsync() > 0;
    }
}
