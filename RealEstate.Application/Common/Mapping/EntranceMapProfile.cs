using AutoMapper;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;

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
