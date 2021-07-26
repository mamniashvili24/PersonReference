using System.Linq;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.CQRS.Queries;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Queries.Report
{
    public class ReportQueryHandler : IQueryHandler<ReportQuery, IDataResponse<IEnumerable<ReportQueryRespons>>>
    {
        #region [ Constructor(s) ]

        public ReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse<IEnumerable<ReportQueryRespons>>> Handle(ReportQuery request, CancellationToken cancellationToken)
        {
            var result = new List<ReportQueryRespons>();
            var persons = await _unitOfWork.PersonRepository.GetAllAsync();
            foreach (var person in persons)
            {
                var relatedPersons = await _unitOfWork.RelatedPersonRepository.WhereAsync(x => x.Person.Id == person.Id, cancellationToken);
                var uniceRelatedPersonTypeIds = relatedPersons.Select(x => x.RelatedPersonType.Id).Distinct().ToList();
                var listTypeAndCount = GetTypeAndCounts(uniceRelatedPersonTypeIds, relatedPersons);

                result.Add(new ReportQueryRespons
                {
                    Person = person,
                    TypeAndCount = listTypeAndCount
                });
            }

            return new DataResponse<IEnumerable<ReportQueryRespons>> { Data = result };
        }

        #endregion

        #region [ Private Method(s) ]

        private IEnumerable<TypeAndCount> GetTypeAndCounts(IEnumerable<int> relatedPersonTypeIds, IEnumerable<PersonRelatedPerson> personRelatedPeoples)
        {
            foreach (var relatedPersonTypeId in relatedPersonTypeIds)
            {
                yield return new TypeAndCount
                {
                    Count = personRelatedPeoples.Count(x => x.RelatedPersonType.Id == relatedPersonTypeId),
                    Type = _unitOfWork.RelatedPersonTypeRepository.GetById(relatedPersonTypeId).Type
                };
            }
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion
    }
}