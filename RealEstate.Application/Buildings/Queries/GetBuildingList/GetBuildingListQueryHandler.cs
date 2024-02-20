using AutoMapper;
using MediatR;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Queries.GetBuildingList
{
    public class GetBuildingListQueryHandler : IRequestHandler<GetBuildingsQuery, BuildingsResponse>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public GetBuildingListQueryHandler(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<BuildingsResponse> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Building> buildings = await _buildingRepository.GetAllAsync();

            var response = new BuildingsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleBuildingResponse>>(buildings)
            };

            return response;
        }
    }
}
