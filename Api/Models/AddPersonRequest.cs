using System;

namespace Api.Models
{
    public class AddPersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string GenderName { get; set; }
        public int CityId { get; set; }
        public string RelatedPersonType { get; set; }
        public int RelatedPersonId { get; set; }
    }
}