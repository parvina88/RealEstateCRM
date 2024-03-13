namespace RealEstate.Contract.Apartment;

public record GetApartmentsByEntranceQuery(Guid EntranceId) : IRequest<ApartmentsResponse>
{

}