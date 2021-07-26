using System;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Commands.UpdatePerson
{
    public class UpdatePersonCommand : ICommand<IDataResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
    }
}