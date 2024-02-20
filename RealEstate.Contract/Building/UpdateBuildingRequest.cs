using MediatR;
using RealEstate.Domain.Enums;
using System.Text.Json.Serialization;

namespace RealEstate.Contract.Building;

public record UpdateBuildingRequest : IRequest<SingleBuildingResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int YearOfConstruction { get; set; }
    public BuildingMaterial? BuildingMaterial { get; set; }
    public ApartmentClass? ApartmentClass { get; set; }
}