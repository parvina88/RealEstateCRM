using MediatR;

namespace RealEstate.Contract.Entrance;

public record GetEntrancesByBuildingQuery(Guid BuildingId) : IRequest<EntrancesResponse>
{

}