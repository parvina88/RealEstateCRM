using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Interfaces;

public interface IApartmentRepository
{
    Task<IEnumerable<Apartment>> GetAllAsync(CancellationToken token = default);
    Task<Apartment> GetAsync(Guid id, CancellationToken token = default);
    Task<IEnumerable<Apartment>> GetAllByEntranceAsync(Guid entranceId, CancellationToken token = default);
    Task<IEnumerable<Apartment>> GetAllByStatusAsync(ApartmentStatus status, CancellationToken token = default);
    Task<Apartment> CreateAsync(Apartment apartment, CancellationToken token = default);
    Task<bool> UpdateAsync(Apartment apartment, CancellationToken token = default);
    Task<bool> DeleteAsync(Apartment apartment, CancellationToken token = default);
}
