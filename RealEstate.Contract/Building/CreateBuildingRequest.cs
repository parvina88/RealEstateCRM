namespace RealEstate.Contract.Building;

public record CreateBuildingRequest : IRequest<SingleBuildingResponse>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int YearOfConstruction { get; set; }
    public BuildingMaterial? BuildingMaterial { get; set; }
    public ApartmentClass? ApartmentClass { get; set; }
}