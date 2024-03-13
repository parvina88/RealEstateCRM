using RealEstate.Contract.Entrance;

namespace RealEstate.Application.Buildings.Queries.GetAllByBuilding;

public class GetAllByBuildingQueryHandler : IRequestHandler<GetEntrancesByBuildingQuery, EntrancesResponse>
{
    private readonly IEntranceRepository _entranceRepository;
    private readonly IMapper _mapper;

    public GetAllByBuildingQueryHandler(IEntranceRepository entranceRepository, IMapper mapper)
    {
        _entranceRepository = entranceRepository;
        _mapper = mapper;
    }

    public async Task<EntrancesResponse> Handle(GetEntrancesByBuildingQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Entities.Entrance> entrances = await _entranceRepository.GetAllByBuildingAsync(request.BuildingId, cancellationToken);

        return new EntrancesResponse()
        {
            Items = _mapper.Map<IEnumerable<SingleEntranceResponse>>(entrances)
        };
    }
}
