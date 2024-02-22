using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Commands.DeleteBuilding;

public class DeleteBuildingCommandHandler(IBuildingRepository buildingRepository) : IRequestHandler<DeleteBuildingRequest, bool>
{
    private readonly IBuildingRepository _buildingRepository = buildingRepository;

    public async Task<bool> Handle(DeleteBuildingRequest request, CancellationToken cancellationToken)
    {
        var building = await _buildingRepository.GetAsync(request.Id) ?? throw new NotFoundException(nameof(Building), request.Id);
        
        return await _buildingRepository.DeleteAsync(building);
    }
}