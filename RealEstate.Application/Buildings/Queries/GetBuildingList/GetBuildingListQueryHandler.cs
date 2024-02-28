using AutoMapper;
using MediatR;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Queries.GetBuildingList
{
    public class GetBuildingListQueryHandler(IBuildingRepository buildingRepository, IMapper mapper) : IRequestHandler<GetBuildingsQuery, BuildingsResponse>
    {
        private readonly IBuildingRepository _buildingRepository = buildingRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BuildingsResponse> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Building> buildings = await _buildingRepository.GetAllAsync(cancellationToken);

            return new BuildingsResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleBuildingResponse>>(buildings)
            };
        }
    }
}
