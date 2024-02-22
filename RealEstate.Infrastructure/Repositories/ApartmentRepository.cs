using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Infrastructure.Repositories;

public class ApartmentRepository(IApplicationDbContext context) : IApartmentRepository
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Apartment> CreateAsync(Apartment apartment)
    {
        await _context.Apartments.AddAsync(apartment);
        await _context.SaveChangesAsync();
        
        return apartment;
    }

    public async Task<IEnumerable<Apartment>> GetAllAsync()
    {
        return await _context.Apartments.ToListAsync();
    }

    public async Task<IEnumerable<Apartment>> GetApartmentsByEntranceAsync(Guid entranceId)
    {
        return await _context.Apartments.Where(a => a.EntranceId == entranceId).ToListAsync();
    }

    public async Task<IEnumerable<Apartment>> GetApartmentsByStatusAsync(ApartmentStatus status)
    {
        return await _context.Apartments.Where(a => a.Status == status).ToListAsync();
    }

    public async Task<Apartment> GetAsync(Guid id)
    {
        return await _context.Apartments.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<bool> UpdateAsync(Apartment apartment)
    {
        _context.Apartments.Update(apartment);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Apartment apartment)
    {
        _context.Apartments.Remove(apartment);
        return await _context.SaveChangesAsync() > 0;
    }
}
