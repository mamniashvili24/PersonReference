using FluentValidation;

namespace Application.Commands.UpdatePersonCity
{
    public class UpdatePersonCityCommandValidator : AbstractValidator<UpdatePersonCityCommand>
    {
        public UpdatePersonCityCommandValidator()
        {
            RuleFor(o => o.PersonId).GreaterThan(0).WithMessage("Model.Invalid.PersonId");
            RuleFor(o => o.CityId).GreaterThan(0).WithMessage("Model.Invalid.CityId");
        }
    }
}