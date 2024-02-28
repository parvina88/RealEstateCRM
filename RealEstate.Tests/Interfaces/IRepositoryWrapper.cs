using RealEstate.Domain.Interfaces;

namespace RealEstate.Tests.Interfaces;

public interface IRepositoryWrapper
{
    IBuildingRepository Building { get; }
    IEntranceRepository Entrance { get; }
    IApartmentRepository Apartment { get; }
}
