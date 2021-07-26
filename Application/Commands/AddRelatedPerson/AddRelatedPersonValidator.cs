using FluentValidation;

namespace Application.Commands.AddRelatedPerson
{
    public class AddRelatedPersonValidator : AbstractValidator<AddRelatedPersonCommand>
    {
        public AddRelatedPersonValidator()
        {
            RuleFor(o => o.PersonId).GreaterThan(0).WithMessage("Model.Invalid.PersonId");
            RuleFor(o => o.RelatedPersonId).GreaterThan(0).WithMessage("Model.Invalid.RelatedPersonId");
            RuleFor(o => o.RelatedPersonType).NotEmpty().NotNull().WithMessage("Model.Invalid.RelatedPersonType");
        }
    }
}