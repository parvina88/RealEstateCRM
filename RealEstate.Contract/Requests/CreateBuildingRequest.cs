using RealEstate.Application.Entities;

namespace RealEstate.Contract.Requests;

public class CreateBuildingRequest
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public int NumberOfFloors { get; set; }
    public double TotalArea { get; set; }
    public int YearOfConstruction { get; set; }
    public string WallMaterial { get; set; }
    public IEnumerable<ApartmentType> ApartmentTypes { get; set; }
}