using FluentValidation;

namespace Application.Queries.GetPersonById
{
    public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdQueryValidator()
        {
            RuleFor(o => o.Id).NotNull().GreaterThan(0).WithMessage("Model.Invalid.PersonId");
        }
    }
}