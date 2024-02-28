using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Infrastructure.Repositories;

public class ApartmentRepository(IApplicationDbContext context) : IApartmentRepository
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Apartment> CreateAsync(Apartment apartment, CancellationToken token = default)
    {
        await _context.Apartments.AddAsync(apartment, token);
        await _context.SaveChangesAsync(token);
        
        return apartment;
    }

    public async Task<IEnumerable<Apartment>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.Apartments.ToListAsync(token);
    }

    public async Task<IEnumerable<Apartment>> GetAllByEntranceAsync(Guid entranceId, CancellationToken token = default)
    {
        return await _context.Apartments.Where(a => a.EntranceId == entranceId).ToListAsync(token);
    }

    public async Task<IEnumerable<Apartment>> GetAllByStatusAsync(ApartmentStatus status, CancellationToken token = default)
    {
        return await _context.Apartments.Where(a => a.Status == status).ToListAsync(token);
    }

    public async Task<Apartment> GetAsync(Guid id, CancellationToken token = default)
    {
        return await _context.Apartments.FirstOrDefaultAsync(a => a.Id == id, token);
    }

    public async Task<bool> UpdateAsync(Apartment apartment, CancellationToken token = default)
    {
        _context.Apartments.Update(apartment);
        return await _context.SaveChangesAsync(token) > 0;
    }

    public async Task<bool> DeleteAsync(Apartment apartment, CancellationToken token = default)
    {
        _context.Apartments.Remove(apartment);
        return await _context.SaveChangesAsync(token) > 0;
    }
}
