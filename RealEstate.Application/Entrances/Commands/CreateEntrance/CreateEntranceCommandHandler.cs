using AutoMapper;
using MediatR;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Exceptions;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Entrances.Commands.CreateEntrance;

public class CreateEntranceCommandHandler : IRequestHandler<CreateEntranceRequest, SingleEntranceResponse>
{
    private readonly IEntranceRepository _entranceRepository;
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;

    public CreateEntranceCommandHandler(IEntranceRepository entranceRepository, IBuildingRepository buildingRepository, IMapper mapper)
    {
        _entranceRepository = entranceRepository;
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<SingleEntranceResponse> Handle(CreateEntranceRequest request, CancellationToken cancellationToken)
    {
        var building = await _buildingRepository.GetAsync(request.BuildingId) ?? throw new NotFoundException(nameof(Building), request.BuildingId);

        var entrance = new Entrance()
        {
            Id = Guid.NewGuid(),
            Number = request.Number,
            NumberOfFloors = request.NumberOfFloors,
            NumberOfApartmentsPerFloor = request.NumberOfApartmentsOnFloor,
            CeilingHeight = request.CeilingHeight,
            HasLift = request.HasLift,
            BuildingId = building.Id
        };

        await _entranceRepository.CreateAsync(entrance);

        return _mapper.Map<SingleEntranceResponse>(entrance);
    }
}
