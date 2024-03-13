using RealEstate.Contract.Apartment;

namespace RealEstate.Application.Apartments.Commands.CreateApartment;

public class CreateApartmentCommandValidator : AbstractValidator<CreateApartmentRequest>
{
    public CreateApartmentCommandValidator()
    {
        RuleFor(x => x.Number).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Floor).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.NumberOfRooms).NotEmpty().GreaterThan(0);
        RuleFor(x => x.TotalArea).NotEmpty().GreaterThan(0);
        RuleFor(x => x.LivingArea).NotEmpty().GreaterThan(0);
        RuleFor(x => x.PricePerSquare).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.EntranceId).NotEmpty();
    }
}
