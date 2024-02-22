using AutoMapper;
using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Contract.Building;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;

namespace RealEstate.Application.Buildings.Queries.GetBuildingDetails
{
    public class GetBuildingDetailQueryHandler(IBuildingRepository buildingRepository, IMapper mapper) : IRequestHandler<GetSingleBuildingQuery, SingleBuildingResponse>
    {
        private readonly IBuildingRepository _buildingRepository = buildingRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<SingleBuildingResponse> Handle(GetSingleBuildingQuery request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetAsync(request.BuildingId) ?? throw new NotFoundException(nameof(Building), request.BuildingId);

            return _mapper.Map<SingleBuildingResponse>(building);
        }
    }
}
