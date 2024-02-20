using AutoMapper;
using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Contract.Building;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Queries.GetEntranceDetail;

public class GetEntranceDetailQueryHandler : IRequestHandler<GetSingleEntranceQuery, SingleEntranceResponse>
{
    private readonly IEntranceRepository _entranceRepository;
    private readonly IMapper _mapper;

    public GetEntranceDetailQueryHandler(IEntranceRepository entranceRepository, IMapper mapper)
    {
        _entranceRepository = entranceRepository;
        _mapper = mapper;
    }

    public async Task<SingleEntranceResponse> Handle(GetSingleEntranceQuery request, CancellationToken cancellationToken)
    {
        var entrance = await _entranceRepository.GetAsync(request.EntranceId);

        if (entrance == null)
            throw new NotFoundException(nameof(Entrance), request.EntranceId);

        return _mapper.Map<SingleEntranceResponse>(entrance);
    }
}
