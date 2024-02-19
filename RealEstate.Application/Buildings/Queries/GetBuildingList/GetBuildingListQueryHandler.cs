using MediatR;
using RealEstate.Application.Mapping;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Repositories;

namespace RealEstate.Application.Buildings.Queries.GetBuildingList
{
    public class GetBuildingListQueryHandler : IRequestHandler<GetBuildingsQuery, BuildingsResponse>
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetBuildingListQueryHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<BuildingsResponse> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Building> buildings = await _buildingRepository.GetAllAsync();
            return buildings.MapToResponse();
        }
    }
}
