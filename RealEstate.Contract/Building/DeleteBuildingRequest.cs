namespace RealEstate.Contract.Building;

public record DeleteBuildingRequest(Guid Id) : IRequest<bool>;
