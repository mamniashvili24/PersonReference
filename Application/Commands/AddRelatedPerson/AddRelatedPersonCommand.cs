using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Commands.AddRelatedPerson
{
    public class AddRelatedPersonCommand : ICommand<IDataResponse>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public string RelatedPersonType { get; set; }
    }
}