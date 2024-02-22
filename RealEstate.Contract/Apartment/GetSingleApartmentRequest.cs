using MediatR;

namespace RealEstate.Contract.Apartment;

public record GetSingleApartmentRequest (Guid ApartmentId) : IRequest<SingleApartmentResponse>;

