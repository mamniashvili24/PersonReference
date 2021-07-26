using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommand : ICommand<IDataResponse>
    {
        public int Id { get; set; }
    }
}