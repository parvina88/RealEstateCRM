using RealEstate.Contract.Building;

namespace RealEstate.Application.Buildings.Commands.DeleteBuilding;

public class DeleteBuildingCommandHandler(IBuildingRepository buildingRepository) : IRequestHandler<DeleteBuildingRequest, bool>
{
    private readonly IBuildingRepository _buildingRepository = buildingRepository;

    public async Task<bool> Handle(DeleteBuildingRequest request, CancellationToken cancellationToken)
    {
        var building = await _buildingRepository.GetAsync(request.Id, cancellationToken) ?? throw new NotFoundException(nameof(Building), request.Id);
        
        return await _buildingRepository.DeleteAsync(building);
    }
}