using MediatR;

namespace RealEstate.Contract.Building;

public record GetSingleBuildingQuery : IRequest<SingleBuildingResponse>
{
    public Guid BuildingId { get; set; }
}
