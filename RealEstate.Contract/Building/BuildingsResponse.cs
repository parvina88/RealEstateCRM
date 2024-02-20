namespace RealEstate.Contract.Building;

public record BuildingsResponse
{
    public IEnumerable<SingleBuildingResponse> Items { get; set; } = Enumerable.Empty<SingleBuildingResponse>();
}