using FluentValidation;
using RealEstate.Contract.Building;

namespace RealEstate.Application.Buildings.Queries.GetBuildingDetail
{
    public class GetBuildingDetailValidator : AbstractValidator<GetSingleBuildingQuery>
    {
        public GetBuildingDetailValidator()
        {
            RuleFor(x => x.BuildingId).NotEmpty();
        }
    }
}
