namespace RealEstate.Contract.Responses;

public class BuildingsResponse
{
    public IEnumerable<BuildingResponse> Items { get; set; } = Enumerable.Empty<BuildingResponse>();
}