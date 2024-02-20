using AutoMapper;
using MediatR;
using RealEstate.Application.Common.Mapping;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Commands.CreateBuilding;

public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingRequest, SingleBuildingResponse>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;

    public CreateBuildingCommandHandler(IBuildingRepository buildingRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<SingleBuildingResponse> Handle(CreateBuildingRequest request, CancellationToken cancellationToken)
    {
        var building = new Building
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            YearOfConstruction = request.YearOfConstruction,
            ApartmentClass = request.ApartmentClass,
            BuildingMaterial = request.BuildingMaterial
        };

        await _buildingRepository.CreateAsync(building, cancellationToken);

        return _mapper.Map<SingleBuildingResponse>(building);
    }
}
