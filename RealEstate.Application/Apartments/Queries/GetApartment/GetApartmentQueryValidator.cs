using FluentValidation;
using RealEstate.Contract.Apartment;

namespace RealEstate.Application.Apartments.Queries.GetApartment;

public class GetApartmentQueryValidator : AbstractValidator<GetSingleApartmentRequest>
{
    public GetApartmentQueryValidator()
    {
        RuleFor(x => x.ApartmentId).NotEmpty();
    }
}
