using System.Linq;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Mapping;
using Infrastructure.CQRS.Queries;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IQueryHandler<GetPersonByIdQuery, IDataResponse<GetPersonByIdQueryRespons>>
    {
        #region [ Constructor(s) ]

        public GetPersonByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse<GetPersonByIdQueryRespons>> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken)
        {
            var person = _unitOfWork.PersonRepository.GetById(query.Id);
            if (person == null)
            {
                return new DataResponse<GetPersonByIdQueryRespons>
                {
                    IsError = true,
                    Message = "Person.ByThisId.NotExist"
                };
            }

            var relatedPersons = await _unitOfWork.RelatedPersonRepository.WhereAsync(x => x.Person.Id == query.Id, cancellationToken);

            var result = new DataResponse<GetPersonByIdQueryRespons>
            {
                Data = Mapping.Map<Person, GetPersonByIdQueryRespons>(person)
            };

            result.Data.PersonRelatedPersons = relatedPersons.Select(r => r.RelatedPerson);
            return result;
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;
        
        #endregion
    }
}