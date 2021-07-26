using Domain.Entities;
using System.Collections.Generic;
using Infrastructure.CQRS.Queries;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Queries.SearchPerson
{
    public class SearchPersonQuery : IQuery<IDataResponse<IEnumerable<Person>>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
    }
}