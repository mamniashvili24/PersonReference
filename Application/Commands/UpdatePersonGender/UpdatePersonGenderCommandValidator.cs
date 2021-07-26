using FluentValidation;

namespace Application.Commands.UpdatePersonGender
{
    public class UpdatePersonCityCommandValidator : AbstractValidator<UpdatePersonGenderCommand>
    {
        public UpdatePersonCityCommandValidator()
        {
            RuleFor(o => o.GenderName).NotEmpty().NotNull().WithMessage("Model.Invalid.GenderName");
            RuleFor(o => o.PersonId).GreaterThan(0).WithMessage("Model.Invalid.PersonId");
        }
    }
}