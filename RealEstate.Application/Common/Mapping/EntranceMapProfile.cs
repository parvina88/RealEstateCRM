using RealEstate.Contract.Entrance;

namespace RealEstate.Application.Common.Mapping;

public class EntranceMapProfile : Profile
{
    public EntranceMapProfile()
    {
        CreateMap<Entrance, SingleEntranceResponse>();
        CreateMap<CreateEntranceRequest, Entrance>();
        CreateMap<GetEntrancesQuery, EntrancesResponse>();
    }
}
