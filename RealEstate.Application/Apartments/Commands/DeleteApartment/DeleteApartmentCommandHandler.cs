using MediatR;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Apartments.Commands.DeleteApartment;

public class DeleteApartmentCommandHandler(IApartmentRepository apartmentRepository) : IRequestHandler<DeleteApartmentRequest, bool>
{
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;

    public async Task<bool> Handle(DeleteApartmentRequest request, CancellationToken cancellationToken)
    {
        var apartment = await _apartmentRepository.GetAsync(request.Id) ?? throw new ValidationFailedException("Apartment", nameof(request.Id));
        return await _apartmentRepository.DeleteAsync(apartment);
    }
}
