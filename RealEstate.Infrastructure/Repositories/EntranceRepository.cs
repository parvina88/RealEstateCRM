using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Infrastructure.Repositories;

public class EntranceRepository : IEntranceRepository
{
    private readonly IApplicationDbContext _context;

    public EntranceRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Entrance entrance)
    {
        _context.Entrances.Add(entrance);
        var rowAffected = await _context.SaveChangesAsync();
        return rowAffected > 0;
    }

    public async Task<IEnumerable<Entrance>> GetAllAsync()
    {
        List<Entrance> entrances = await _context.Entrances
            .Include(x => x.Building)
            .ToListAsync();

        entrances = entrances.Where(e => !string.IsNullOrWhiteSpace(e.Building.Name)).ToList();

        return entrances;
    }

    public async Task<Entrance?> GetAsync(Guid id)
    {
        return await _context.Entrances.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(Entrance entrance)
    {
        _context.Entrances.Update(entrance);
        var rowAffected = await _context.SaveChangesAsync();
        return rowAffected > 0;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var entranceToDelete = await GetAsync(id);

        if (entranceToDelete == null)
            return false;

        _context.Entrances.Remove(entranceToDelete);

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;
    }
}
