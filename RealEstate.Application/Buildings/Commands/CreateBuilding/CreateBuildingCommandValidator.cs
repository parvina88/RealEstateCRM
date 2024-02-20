using FluentValidation;
using RealEstate.Contract.Building;

namespace RealEstate.Application.Buildings.Commands.CreateBuilding;

public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingRequest>
{
    public CreateBuildingCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.YearOfConstruction).NotEmpty();
    }
}
