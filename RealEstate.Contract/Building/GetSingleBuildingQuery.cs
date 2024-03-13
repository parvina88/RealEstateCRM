namespace RealEstate.Contract.Building;

public record GetSingleBuildingQuery(Guid BuildingId) : IRequest<SingleBuildingResponse>;

