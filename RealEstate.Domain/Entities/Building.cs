using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class Building
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public int YearOfConstruction { get; set; }
    public BuildingMaterial BuildingMaterial { get; set; }
    public ApartmentClass? ApartmentClass;
}