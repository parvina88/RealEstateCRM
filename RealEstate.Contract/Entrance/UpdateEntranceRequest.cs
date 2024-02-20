using MediatR;
using RealEstate.Contract.Building;

namespace RealEstate.Contract.Entrance;

public record UpdateEntranceRequest : IRequest<SingleEntranceResponse>
{

}