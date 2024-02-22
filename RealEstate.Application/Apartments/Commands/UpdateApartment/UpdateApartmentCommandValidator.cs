using FluentValidation;
using RealEstate.Contract.Apartment;

namespace RealEstate.Application.Apartments.Commands.UpdateApartment;

public class UpdateApartmentCommandValidator : AbstractValidator<UpdateApartmentRequest>
{
    public UpdateApartmentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.Floor).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.NumberOfRooms).NotEmpty().GreaterThan(0);
        RuleFor(x => x.PricePerSquare).NotEmpty().GreaterThan(0);
        RuleFor(x => x.TotalArea).NotEmpty().GreaterThan(0);
        RuleFor(x => x.LivingArea).NotEmpty().GreaterThan(0);
        RuleFor(x => x.EntranceId).NotEmpty();
    }
}
