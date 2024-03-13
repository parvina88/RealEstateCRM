namespace RealEstate.Infrastructure.Repositories;

public class BuildingRepository(IApplicationDbContext context) : IBuildingRepository
{
    private readonly IApplicationDbContext _context = context;

    public async Task<bool> CreateAsync(Building building, CancellationToken token = default)
    {
        await _context.Buildings.AddAsync(building, token);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Building?> GetAsync(Guid id, CancellationToken token = default)
    {
        return await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id, token);
    }

    public async Task<IEnumerable<Building>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.Buildings.ToListAsync(token);
    }

    public async Task<bool> UpdateAsync(Building building, CancellationToken token = default)
    {
        _context.Buildings.Update(building);
        return await _context.SaveChangesAsync(token) > 0;
    }

    public async Task<bool> DeleteAsync(Building building, CancellationToken token = default)
    {
        _context.Buildings.Remove(building);

        return await _context.SaveChangesAsync(token) > 0;
    }
}