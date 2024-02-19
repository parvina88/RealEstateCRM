using MediatR;
using RealEstate.Application.Mapping;
using RealEstate.Contract.Building;
using RealEstate.Domain.Repositories;

namespace RealEstate.Application.Buildings.Commands.CreateBuilding;

public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingRequest, SingleBuildingResponse>
{
    private readonly IBuildingRepository _buildingRepository;

    public CreateBuildingCommandHandler(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository;
    }

    public async Task<SingleBuildingResponse> Handle(CreateBuildingRequest request, CancellationToken cancellationToken)
    {
        var building = request.MapToBuilding();
        
        return await _buildingRepository.CreateAsync(building, cancellationToken)
            ? building.MapToResponse()
            : throw new Exception("Failed to create building");
    }
}
