namespace RealEstate.Contract.Building;

public class BuildingsResponse
{
    public IEnumerable<SingleBuildingResponse> Items { get; set; } = Enumerable.Empty<SingleBuildingResponse>();
}