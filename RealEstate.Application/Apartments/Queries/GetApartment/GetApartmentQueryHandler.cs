﻿using AutoMapper;
using MediatR;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Apartments.Queries.GetApartment;

public class GetApartmentQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper) : IRequestHandler<GetSingleApartmentRequest, SingleApartmentResponse>
{
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SingleApartmentResponse> Handle(GetSingleApartmentRequest request, CancellationToken cancellationToken)
    {
        var apartment = await _apartmentRepository.GetAsync(request.ApartmentId, cancellationToken) ?? throw new NotFoundException(nameof(Apartment), request.ApartmentId);

        return _mapper.Map<SingleApartmentResponse>(apartment);
    }
}
