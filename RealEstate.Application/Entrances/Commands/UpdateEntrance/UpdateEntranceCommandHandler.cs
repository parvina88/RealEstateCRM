using AutoMapper;
using MediatR;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Commands.UpdateEntrance;

public class UpdateEntranceCommandHandler(IEntranceRepository entranceRepository, IMapper mapper) : IRequestHandler<UpdateEntranceRequest, SingleEntranceResponse>
{
    private readonly IEntranceRepository _entranceRepository = entranceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SingleEntranceResponse> Handle(UpdateEntranceRequest request, CancellationToken cancellationToken)
    {
        var entrance = await _entranceRepository.GetAsync(request.Id) ?? throw new NotFoundException(nameof(Entrance), request.Id);

        await _entranceRepository.UpdateAsync(entrance);

        return _mapper.Map<SingleEntranceResponse>(entrance);
    }
}
