using RealEstate.Contract.Entrance;

namespace RealEstate.Application.Entrances.Commands.UpdateEntrance;

public class UpdateEntranceCommandValidator : AbstractValidator<UpdateEntranceRequest>
{
    public UpdateEntranceCommandValidator()
    {
        RuleFor(e => e.Number).NotEmpty();
        RuleFor(e => e.BuildingId).NotEmpty();
        RuleFor(e => e.NumberOfFloors).NotEmpty().GreaterThan(0);
        RuleFor(e => e.NumberOfApartmentsPerFloor).NotEmpty().GreaterThan(0);
        RuleFor(e => e.CeilingHeight).NotEmpty().GreaterThan(0);
        RuleFor(e => e.HasLift).NotNull();
    }
}
