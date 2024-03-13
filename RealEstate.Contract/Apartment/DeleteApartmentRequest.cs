namespace RealEstate.Contract.Apartment;

public record DeleteApartmentRequest(Guid Id) : IRequest<bool>
{

}
