using FluentValidation;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Repositories;

namespace RealEstate.Application.Validators
{
    public class BuildingValidator : AbstractValidator<Building>
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingValidator(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;

            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Address)
                .NotEmpty();
        }
    }
}
