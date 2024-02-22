using AutoMapper;
using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Queries.GetEntranceDetail;

public class GetEntranceDetailQueryHandler(IEntranceRepository entranceRepository, IMapper mapper) : IRequestHandler<GetSingleEntranceQuery, SingleEntranceResponse>
{
    private readonly IEntranceRepository _entranceRepository = entranceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SingleEntranceResponse> Handle(GetSingleEntranceQuery request, CancellationToken cancellationToken)
    {
        Entrance entrance = await _entranceRepository.GetAsync(request.Id) ?? throw new NotFoundException(nameof(Entrance), request.Id);
        return _mapper.Map<SingleEntranceResponse>(entrance);
    }
}
