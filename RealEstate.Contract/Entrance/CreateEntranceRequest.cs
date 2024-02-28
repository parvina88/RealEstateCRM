using MediatR;

namespace RealEstate.Contract.Entrance;

public record CreateEntranceRequest : IRequest<SingleEntranceResponse>
{
    public string Number { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfApartmentsPerFloor { get; set; }
    public double CeilingHeight { get; set; }
    public bool HasLift { get; set; }
    public Guid BuildingId { get; set; }
}