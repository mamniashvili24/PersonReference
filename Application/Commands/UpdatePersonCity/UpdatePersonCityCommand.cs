using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Commands.UpdatePersonCity
{
    public class UpdatePersonCityCommand : ICommand<IDataResponse>
    {
        public int PersonId { get; set; }
        public int CityId { get; set; }
    }
}