using MediatR;
using RealEstate.Contract.Building;
using RealEstate.Domain.Repositories;

namespace RealEstate.Application.Buildings.Commands.DeleteBuilding;

public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingRequest, bool>
{
    private readonly IBuildingRepository _buildingRepository;

    public DeleteBuildingCommandHandler(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository;
    }

    public async Task<bool> Handle(DeleteBuildingRequest request, CancellationToken cancellationToken)
    {
        return await _buildingRepository.DeleteAsync(request.Id);
    }
}