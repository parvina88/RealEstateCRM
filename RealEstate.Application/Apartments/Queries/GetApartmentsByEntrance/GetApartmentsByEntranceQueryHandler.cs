using RealEstate.Contract.Apartment;

namespace RealEstate.Application.Apartments.Queries.GetApartmentsByEntrance;

public class GetApartmentsByEntranceQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper) : IRequestHandler<GetApartmentsByEntranceQuery, ApartmentsResponse>
{
    private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ApartmentsResponse> Handle(GetApartmentsByEntranceQuery request, CancellationToken cancellationToken)
    {
        var apartments = await _apartmentRepository.GetAllByEntranceAsync(request.EntranceId);

        return new ApartmentsResponse()
        {
            Items = _mapper.Map<IEnumerable<SingleApartmentResponse>>(apartments)
        };
    }
}