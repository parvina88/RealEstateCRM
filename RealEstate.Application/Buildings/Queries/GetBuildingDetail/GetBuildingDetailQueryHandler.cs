using AutoMapper;
using MediatR;
using RealEstate.Contract.Building;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Queries.GetBuildingDetails
{
    public class GetBuildingDetailQueryHandler : IRequestHandler<GetSingleBuildingQuery, SingleBuildingResponse>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public GetBuildingDetailQueryHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<SingleBuildingResponse> Handle(GetSingleBuildingQuery request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetAsync(request.BuildingId);

            return _mapper.Map<SingleBuildingResponse>(building);
        }
    }
}
