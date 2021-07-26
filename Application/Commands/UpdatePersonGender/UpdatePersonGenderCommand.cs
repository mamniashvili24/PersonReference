using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Commands.UpdatePersonGender
{
    public class UpdatePersonGenderCommand : ICommand<IDataResponse>
    {
        public int PersonId { get; set; }
        public string GenderName { get; set; }
    }
}