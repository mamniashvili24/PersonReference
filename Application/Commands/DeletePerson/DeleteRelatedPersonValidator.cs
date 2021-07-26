using FluentValidation;

namespace Application.Commands.DeletePerson
{
    public class DeleteRelatedPersonValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeleteRelatedPersonValidator()
        {
            RuleFor(o => o.Id).GreaterThan(0).WithMessage("Model.Invalid.PersonId");
        }
    }
}