using RealEstate.Contract.Apartment;

namespace RealEstate.Application.Apartments.Queries.GetApartmentsByStatus;

public class GetApartmentsByStatusQueryValidator : AbstractValidator<GetApartmentsByStatusQuery>
{
    public GetApartmentsByStatusQueryValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Invalid status");
    }
}
