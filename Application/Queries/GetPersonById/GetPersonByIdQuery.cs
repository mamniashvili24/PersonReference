using Infrastructure.CQRS.Queries;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IQuery<IDataResponse<GetPersonByIdQueryRespons>>
    {
        public int Id { get; set; }
    }
}