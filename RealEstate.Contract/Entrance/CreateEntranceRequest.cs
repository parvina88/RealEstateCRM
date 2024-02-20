using MediatR;
using RealEstate.Contract.Entrance;

namespace RealEstate.Contract.Building;

public record CreateEntranceRequest : IRequest<SingleEntranceResponse>
{
    public string Number { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfApartmentsPerFloor { get; set; }
    public double CeilingHeight { get; set; }
    public bool HasLift { get; set; }
    public string Building { get; set; }
}