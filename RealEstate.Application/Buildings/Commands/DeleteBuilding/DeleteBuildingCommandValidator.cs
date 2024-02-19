using FluentValidation;
using RealEstate.Contract.Building;

namespace RealEstate.Application.Buildings.Commands.DeleteBuilding;

public sealed class DeleteBuildingCommandValidator : AbstractValidator<DeleteBuildingRequest>
{
    public DeleteBuildingCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
