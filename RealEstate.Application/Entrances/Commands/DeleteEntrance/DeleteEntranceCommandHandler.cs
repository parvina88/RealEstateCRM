using RealEstate.Contract.Entrance;

namespace RealEstate.Application.Entrances.Commands.DeleteEntrance;

public class DeleteEntranceCommandHandler(IEntranceRepository entranceRepository) : IRequestHandler<DeleteEntranceRequest, bool>
{
    private readonly IEntranceRepository _entranceRepository = entranceRepository;

    public async Task<bool> Handle(DeleteEntranceRequest request, CancellationToken cancellationToken)
    {
        var entrance = await _entranceRepository.GetAsync(request.Id, cancellationToken) ?? throw new NotFoundException(nameof(Entrance), request.Id);
        return await _entranceRepository.DeleteAsync(entrance, cancellationToken);
    }
}
