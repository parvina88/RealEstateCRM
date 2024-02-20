using AutoMapper;
using MediatR;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Commands.UpdateBuilding;

public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingRequest, SingleBuildingResponse>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;

    public UpdateBuildingCommandHandler(IBuildingRepository buildingRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<SingleBuildingResponse> Handle(UpdateBuildingRequest request, CancellationToken cancellationToken)
    {
        Building? building = await _buildingRepository.GetAsync(request.Id);
        
        if (building == null)
            throw new Exception();

        building.Name = request.Name;
        building.Address = request.Address;
        building.YearOfConstruction = request.YearOfConstruction;
        building.BuildingMaterial = request.BuildingMaterial;
        building.ApartmentClass = request.ApartmentClass;

        await _buildingRepository.UpdateAsync(building);

        return _mapper.Map<SingleBuildingResponse>(building);
    }
}
