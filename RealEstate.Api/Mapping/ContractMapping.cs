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
                ApartmentClass = request.ApartmentClass,
                BuildingMaterial = request.BuildingMaterial
            };

        }
    }
}
