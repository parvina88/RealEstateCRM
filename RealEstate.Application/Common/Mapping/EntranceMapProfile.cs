using AutoMapper;
using RealEstate.Contract.Building;
using RealEstate.Contract.Entrance;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Common.Mapping;

public class EntranceMapProfile : Profile
{
    public EntranceMapProfile()
    {
        CreateMap<CreateEntranceRequest, Entrance>();
        CreateMap<GetEntrancesQuery, EntrancesResponse>();
    }
}
