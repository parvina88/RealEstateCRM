using MediatR;

namespace RealEstate.Contract.Apartment;

public record GetApartmentsQuery : IRequest<ApartmentsResponse>
{
}
