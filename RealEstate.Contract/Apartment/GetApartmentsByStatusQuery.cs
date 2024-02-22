using MediatR;
using RealEstate.Domain.Enums;

namespace RealEstate.Contract.Apartment;

public record GetApartmentsByStatusQuery(ApartmentStatus Status) : IRequest<ApartmentsResponse>
{
}
