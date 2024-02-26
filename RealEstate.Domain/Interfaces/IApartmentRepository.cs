using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Interfaces;

public interface IApartmentRepository
{
    Task<IEnumerable<Apartment>> GetAllAsync();
    Task<Apartment> GetAsync(Guid id);
    Task<IEnumerable<Apartment>> GetAllByEntranceAsync(Guid entranceId);
    Task<IEnumerable<Apartment>> GetAllByStatusAsync(ApartmentStatus status);
    Task<Apartment> CreateAsync(Apartment apartment);
    Task<bool> UpdateAsync(Apartment apartment);
    Task<bool> DeleteAsync(Apartment apartment);
}
