namespace RealEstate.Application.Entities;

public class Building
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
    public string Address { get; set; }
    public int NumberOfFloors { get; set; }
    public double TotalArea { get; set; }
    public int YearOfConstruction { get; set; }
    public string WallMaterial { get; set; }
    public List<ApartmentType> ApartmentTypes { get; set; }
}