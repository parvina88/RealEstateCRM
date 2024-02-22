using AutoMapper;
using MediatR;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Apartments.Queries.GetApartmentsByStatus;

public class GetApartmentsByStatusHandler(IApartmentRepository apartmentRepository, IMapper mapper) : IRequestHandler<GetApartmentsByStatusQuery, ApartmentsResponse>
{
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ApartmentsResponse> Handle(GetApartmentsByStatusQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Apartment> apartments = await _apartmentRepository.GetApartmentsByStatusAsync(request.Status);

        return new ApartmentsResponse()
        {
            Items = _mapper.Map<IEnumerable<SingleApartmentResponse>>(apartments)
        };
    }
}
