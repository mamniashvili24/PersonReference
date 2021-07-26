using System;
using FluentValidation;

namespace Application.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonValidator : AbstractValidator<DeleteRelatedPersonCommand>
    {
        public DeleteRelatedPersonValidator()
        {
            RuleFor(o => o.PersonId).GreaterThan(0).WithMessage("Model.Invalid.PersonId");
            RuleFor(o => o.RelatedPersonId).GreaterThan(0).WithMessage("Model.Invalid.RelatedPersonId");
        }
    }
}