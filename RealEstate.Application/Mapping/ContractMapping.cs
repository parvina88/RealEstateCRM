using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Mapping;

public static class ContractMapping
{
    public static Building MapToBuilding(this CreateBuildingRequest request)
    {
        return new Building
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            YearOfConstruction = request.YearOfConstruction,
            ApartmentClass = request.ApartmentClass,
            BuildingMaterial = request.BuildingMaterial
        };
    }

    public static SingleBuildingResponse MapToResponse(this Building building)
    {
        return new SingleBuildingResponse
        {
            Id = building.Id,
            Name = building.Name,
            Address = building.Address,
            YearOfConstruction = building.YearOfConstruction,
            ApartmentClass = building.ApartmentClass,
            BuildingMaterial = building.BuildingMaterial
        };
    }

    public static BuildingsResponse MapToResponse(this IEnumerable<Building> buildings)
    {
        return new BuildingsResponse()
        {
            Items = buildings.Select(MapToResponse)
        };
    }

    public static Building MapToBuilding(this UpdateBuildingRequest request)
    {
        return new Building
        {
            Name = request.Name,
            Address = request.Address,
            YearOfConstruction = request.YearOfConstruction,
            ApartmentClass = request.ApartmentClass,
            BuildingMaterial = request.BuildingMaterial
        };
    }
}
