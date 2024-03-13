using RealEstate.Contract.Building;

namespace RealEstate.Application.Buildings.Queries.GetBuildingDetails
{
    public class GetBuildingDetailQueryHandler(IBuildingRepository buildingRepository, IMapper mapper) : IRequestHandler<GetSingleBuildingQuery, SingleBuildingResponse>
    {
        private readonly IBuildingRepository _buildingRepository = buildingRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<SingleBuildingResponse> Handle(GetSingleBuildingQuery request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetAsync(request.BuildingId, cancellationToken) ?? throw new NotFoundException(nameof(Building), request.BuildingId);

            return _mapper.Map<SingleBuildingResponse>(building);
        }
    }
}
