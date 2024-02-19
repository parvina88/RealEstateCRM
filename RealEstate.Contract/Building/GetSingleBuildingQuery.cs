using MediatR;

namespace RealEstate.Contract.Building
{
    public class GetSingleBuildingQuery : IRequest<SingleBuildingResponse>
    {
        public Guid BuildingId { get; set; }
    }
}
