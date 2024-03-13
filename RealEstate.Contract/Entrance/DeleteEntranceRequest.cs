namespace RealEstate.Contract.Entrance;

public record DeleteEntranceRequest(Guid Id) : IRequest<bool>;
