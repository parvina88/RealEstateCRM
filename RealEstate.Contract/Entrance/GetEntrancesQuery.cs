using MediatR;
using RealEstate.Contract.Building;

namespace RealEstate.Contract.Entrance;

public class GetEntrancesQuery : IRequest<EntrancesResponse>
{
}
