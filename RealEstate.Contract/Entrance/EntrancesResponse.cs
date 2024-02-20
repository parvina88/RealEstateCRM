using RealEstate.Contract.Entrance;

namespace RealEstate.Contract.Building;

public class EntrancesResponse
{
    public IEnumerable<SingleEntranceResponse> Items { get; set; } = Enumerable.Empty<SingleEntranceResponse>();
}