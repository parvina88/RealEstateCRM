using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;

namespace RealEstate.Api.Mapping
{
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
                //ApartmentClass =   (ApartmentClass)Enum.Parse(typeof(ApartmentClass), request.ApartmentClass),
                //BuildingMaterial = (BuildingMaterial)Enum.Parse(typeof(BuildingMaterial), request.BuildingMaterial)
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
    }
}
