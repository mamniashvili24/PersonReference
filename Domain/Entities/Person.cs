using System;

namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual City City { get; set; }
    }
}