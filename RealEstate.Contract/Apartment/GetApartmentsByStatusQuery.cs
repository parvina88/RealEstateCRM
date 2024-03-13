namespace RealEstate.Contract.Apartment;

public record GetApartmentsByStatusQuery(ApartmentStatus Status) : IRequest<ApartmentsResponse>
{
}
