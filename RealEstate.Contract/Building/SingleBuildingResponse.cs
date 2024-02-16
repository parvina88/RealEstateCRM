using RealEstate.Domain.Enums;

namespace RealEstate.Contract.Building;

public class SingleBuildingResponse
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int YearOfConstruction { get; set; }
    public BuildingMaterial? BuildingMaterial { get; set; }
    public ApartmentClass? ApartmentClass { get; set; }
}