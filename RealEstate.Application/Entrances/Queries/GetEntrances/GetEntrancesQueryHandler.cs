using AutoMapper;
using MediatR;
using RealEstate.Contract.Building;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Queries.GetEntrances;

public class GetEntrancesQueryHandler : IRequestHandler<GetEntrancesQuery, EntrancesResponse>
{
    private readonly IEntranceRepository _entranceRepository;
    private readonly IMapper _mapper;

    public GetEntrancesQueryHandler(IEntranceRepository entranceRepository, IMapper mapper)
    {
        _entranceRepository = entranceRepository;
        _mapper = mapper;
    }

    public async Task<EntrancesResponse> Handle(GetEntrancesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Entrance> entrances = await _entranceRepository.GetAllAsync();

        var response = new EntrancesResponse()
        {
            Items = _mapper.Map<IEnumerable<SingleEntranceResponse>>(entrances)
        };

        return response;
    }
}
