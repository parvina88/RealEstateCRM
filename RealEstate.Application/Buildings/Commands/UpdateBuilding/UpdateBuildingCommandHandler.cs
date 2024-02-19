using MediatR;
using RealEstate.Application.Mapping;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Repositories;

namespace RealEstate.Application.Buildings.Commands.UpdateBuilding;

public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingRequest, SingleBuildingResponse>
{
    private readonly IBuildingRepository _buildingRepository;

    public UpdateBuildingCommandHandler(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository;
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

        return await _buildingRepository.UpdateAsync(building) 
            ? building.MapToResponse()
            : throw new Exception("Failed to update building");
    }
}
