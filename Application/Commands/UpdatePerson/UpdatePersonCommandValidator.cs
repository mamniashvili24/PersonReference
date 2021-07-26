using System;
using FluentValidation;

namespace Application.Commands.UpdatePerson
{
    public class UpdatePersonGenderCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonGenderCommandValidator()
        {
            RuleFor(o => o.PersonalNumber).NotEmpty().NotNull().MinimumLength(11).MaximumLength(11).Matches("^[0-9]*$").WithMessage("Model.Invalid.PersonalNumber");
            RuleFor(o => o.FirstName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(50).Matches("[a-zA-Z]+").WithMessage("Model.Invalid.FirstName");
            RuleFor(o => o.LastName).NotEmpty().MinimumLength(2).MaximumLength(50).Matches("[a-zA-Z]+").WithMessage("Model.Invalid.LastName");
            RuleFor(o => o.PhoneNumber).MinimumLength(4).MaximumLength(50).Matches("^[0-9]*$").WithMessage("Model.Invalid.PhoneNumber");
            RuleFor(o => o.Birthday).Must(BeValidAge).WithMessage("Model.Invalid.Age");
            RuleFor(o => o.CityId).GreaterThan(0).WithMessage("Model.Invalid.CityId");
            RuleFor(o => o.Id).GreaterThan(0).WithMessage("Model.Invalid.PersonId");
        }
        protected bool BeValidAge(DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            return age > 18;
        }
    }
}