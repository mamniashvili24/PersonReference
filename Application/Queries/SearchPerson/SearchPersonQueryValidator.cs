using FluentValidation;

namespace Application.Queries.SearchPerson
{
    public class SearchPersonQueryValidator : AbstractValidator<SearchPersonQuery>
    {
        public SearchPersonQueryValidator()
        {

        }
    }
}