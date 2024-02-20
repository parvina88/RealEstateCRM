using MediatR;
using RealEstate.Contract.Entrance;

namespace RealEstate.Contract.Building;

public record GetSingleEntranceQuery : IRequest<SingleEntranceResponse>
{
    public Guid EntranceId { get; set; }
}
