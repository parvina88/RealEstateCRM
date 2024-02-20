using MediatR;

namespace RealEstate.Contract.Building;

public record DeleteEntanceRequest(Guid Id) : IRequest<bool>;
