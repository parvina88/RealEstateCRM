using FluentValidation;
using RealEstate.Contract.Entrance;

namespace RealEstate.Application.Entrances.Commands.CreateEntrance;

public class CreateEntranceCommandValidator : AbstractValidator<CreateEntranceRequest>
{
    public CreateEntranceCommandValidator()
    {
        RuleFor(e => e.Number).NotEmpty();
        RuleFor(e => e.BuildingId).NotEmpty();
        RuleFor(e => e.NumberOfFloors).NotEmpty().GreaterThan(0);
        RuleFor(e => e.NumberOfApartmentsOnFloor).NotEmpty().GreaterThan(0);
        RuleFor(e => e.CeilingHeight).NotEmpty().GreaterThan(0);
        RuleFor(e => e.HasLift).NotNull();
    }
}
