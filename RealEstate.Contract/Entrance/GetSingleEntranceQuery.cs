namespace RealEstate.Contract.Entrance;

public record GetSingleEntranceQuery(Guid Id) : IRequest<SingleEntranceResponse>;