using FluentValidation;
using RealEstate.Contract.Apartment;

namespace RealEstate.Application.Apartments.Queries.GetApartmentsByEntrance;

public class GetApartmentsByEntranceQueryValidator : AbstractValidator<GetApartmentsByEntranceQuery>
{
    public GetApartmentsByEntranceQueryValidator()
    {
        RuleFor(x => x.EntranceId).NotEmpty();
    }
}
