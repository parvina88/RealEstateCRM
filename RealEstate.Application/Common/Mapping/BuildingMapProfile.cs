using RealEstate.Contract.Building;

namespace RealEstate.Application.Common.Mapping;

public class BuildingMapProfile : Profile
{
    public BuildingMapProfile()
    {
        CreateMap<Building, SingleBuildingResponse>();
        CreateMap<CreateBuildingRequest, Building>();
        CreateMap<UpdateBuildingRequest, Building>();
        CreateMap<GetBuildingsQuery, BuildingsResponse>();
    }
}
