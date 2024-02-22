using AutoMapper;
using MediatR;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Queries.GetEntrances;

public class GetEntrancesQueryHandler(IEntranceRepository entranceRepository, IMapper mapper) : IRequestHandler<GetEntrancesQuery, EntrancesResponse>
{
    private readonly IEntranceRepository _entranceRepository = entranceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<EntrancesResponse> Handle(GetEntrancesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Entrance> entrances = await _entranceRepository.GetAllAsync();

        return  new EntrancesResponse()
        {
            Items = _mapper.Map<IEnumerable<SingleEntranceResponse>>(entrances)
        };
    }
}
