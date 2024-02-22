using AutoMapper;
using MediatR;
using RealEstate.Contract.Apartment;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Apartments.Queries.GetApartmentList;

public class GetApartmentListQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper) : IRequestHandler<GetApartmentsQuery, ApartmentsResponse>
{
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ApartmentsResponse> Handle(GetApartmentsQuery request, CancellationToken cancellationToken)
    {
        var apartments = await _apartmentRepository.GetAllAsync();

        return  new ApartmentsResponse()
        {
            Items = _mapper.Map<IEnumerable<SingleApartmentResponse>>(apartments)
        };
    }
}
