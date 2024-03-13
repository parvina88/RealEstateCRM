using RealEstate.Contract.Entrance;

namespace RealEstate.Application.Entrances.Commands.UpdateEntrance;

public class UpdateEntranceCommandHandler(IEntranceRepository entranceRepository, IMapper mapper) : IRequestHandler<UpdateEntranceRequest, SingleEntranceResponse>
{
    private readonly IEntranceRepository _entranceRepository = entranceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SingleEntranceResponse> Handle(UpdateEntranceRequest request, CancellationToken cancellationToken)
    {
        var entrance = await _entranceRepository.GetAsync(request.Id, cancellationToken) ?? throw new NotFoundException(nameof(Entrance), request.Id);

        entrance.Number = request.Number;
        entrance.NumberOfFloors = request.NumberOfFloors;
        entrance.NumberOfApartmentsPerFloor = request.NumberOfApartmentsPerFloor;
        entrance.CeilingHeight = request.CeilingHeight;
        entrance.HasLift = request.HasLift;
        entrance.BuildingId = request.BuildingId;

        await _entranceRepository.UpdateAsync(entrance, cancellationToken);

        return _mapper.Map<SingleEntranceResponse>(entrance);
    }
}
