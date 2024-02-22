using FluentValidation;
using RealEstate.Contract.Entrance;

namespace RealEstate.Application.Entrances.Commands.DeleteEntrance;

public class DeleteEntranceCommandValidator : AbstractValidator<DeleteEntranceRequest>
{
    public DeleteEntranceCommandValidator()
    {
        RuleFor(e => e.Id).NotEmpty();
    }
}
