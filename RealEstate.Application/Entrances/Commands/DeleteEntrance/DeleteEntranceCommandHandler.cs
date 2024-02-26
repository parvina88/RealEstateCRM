using MediatR;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Commands.DeleteEntrance;

public class DeleteEntranceCommandHandler(IEntranceRepository entranceRepository) : IRequestHandler<DeleteEntranceRequest, bool>
{
    private readonly IEntranceRepository _entranceRepository = entranceRepository;

    public async Task<bool> Handle(DeleteEntranceRequest request, CancellationToken cancellationToken)
    {
        var entrance = await _entranceRepository.GetAsync(request.Id) ?? throw new NotFoundException(nameof(Entrance), request.Id);
        return await _entranceRepository.DeleteAsync(entrance);
    }
}
