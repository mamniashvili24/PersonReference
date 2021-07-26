using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonCommand : ICommand<IDataResponse>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}