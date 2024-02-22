using AutoMapper;
using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Commands.UpdateBuilding;

public class UpdateBuildingCommandHandler(IBuildingRepository buildingRepository, IMapper mapper) : IRequestHandler<UpdateBuildingRequest, SingleBuildingResponse>
{
    private readonly IBuildingRepository _buildingRepository = buildingRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SingleBuildingResponse> Handle(UpdateBuildingRequest request, CancellationToken cancellationToken)
    {
        Building building = await _buildingRepository.GetAsync(request.Id) ?? throw new NotFoundException(nameof(Building), request.Id);
        
        building.Name = request.Name;
        building.Address = request.Address;
        building.YearOfConstruction = request.YearOfConstruction;
        building.BuildingMaterial = request.BuildingMaterial;
        building.ApartmentClass = request.ApartmentClass;

        await _buildingRepository.UpdateAsync(building);

        return _mapper.Map<SingleBuildingResponse>(building);
    }
}
