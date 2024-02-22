namespace RealEstate.Contract.Entrance;

public record EntrancesResponse
{
    public IEnumerable<SingleEntranceResponse> Items { get; set; } = Enumerable.Empty<SingleEntranceResponse>();
}