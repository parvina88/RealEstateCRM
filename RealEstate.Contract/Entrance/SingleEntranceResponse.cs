namespace RealEstate.Contract.Entrance;

public record SingleEntranceResponse
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfApartmentsOnFloor { get; set; }
    public double CeilingHeight { get; set; }
    public bool HasLift { get; set; }
    public Guid BuildingId { get; set; }
    }
