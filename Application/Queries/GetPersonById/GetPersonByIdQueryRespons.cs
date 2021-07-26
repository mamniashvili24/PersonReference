using System;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Queries.GetPersonById
{
    public class GetPersonByIdQueryRespons
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public Gender Gender { get; set; }
        public City City { get; set; }
        public IEnumerable<Person> PersonRelatedPersons { get; set; }
    }
}