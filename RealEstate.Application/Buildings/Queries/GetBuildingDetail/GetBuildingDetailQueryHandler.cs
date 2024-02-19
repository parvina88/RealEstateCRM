using MediatR;
using RealEstate.Application.Mapping;
using RealEstate.Contract.Building;
using RealEstate.Domain.Repositories;

namespace RealEstate.Application.Buildings.Queries.GetBuildingDetails
{
    public class GetBuildingDetailQueryHandler : IRequestHandler<GetSingleBuildingQuery, SingleBuildingResponse>
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetBuildingDetailQueryHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<SingleBuildingResponse> Handle(GetSingleBuildingQuery request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetAsync(request.BuildingId);

            return building?.MapToResponse() ?? throw new Exception("Building not found");
        }
    }
}
