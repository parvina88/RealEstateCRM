﻿using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Apartments.Commands.DeleteApartment;

public class DeleteApartmentCommandHandler(IApartmentRepository apartmentRepository) : IRequestHandler<DeleteApartmentRequest, bool>
{
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;

    public async Task<bool> Handle(DeleteApartmentRequest request, CancellationToken cancellationToken)
    {
        var apartment = await _apartmentRepository.GetAsync(request.Id) ?? throw new NotFoundException(nameof(Apartment), request.Id);
        return await _apartmentRepository.DeleteAsync(apartment);
    }
}