using RealEstate.Contract.Building;

namespace RealEstate.Application.Buildings.Commands.UpdateBuilding;

public class UpdateBuildingCommandValidator : AbstractValidator<UpdateBuildingRequest>
{
    public UpdateBuildingCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.YearOfConstruction).NotEmpty();
    }
}
