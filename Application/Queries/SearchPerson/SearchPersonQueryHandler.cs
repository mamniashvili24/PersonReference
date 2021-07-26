using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.CQRS.Queries;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Queries.SearchPerson
{
    public class SearchPersonQueryHandler : IQueryHandler<SearchPersonQuery, IDataResponse<IEnumerable<Person>>>
    {
        #region [ Constructor(s) ]
        
        public SearchPersonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse<IEnumerable<Person>>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
        {
            var persons = await _unitOfWork.PersonRepository.WhereAsync(p => 
                            p.FirstName.ToLower().Contains(request.FirstName.ToLower()) ||
                            p.LastName.ToLower().Contains(request.LastName.ToLower()) || 
                            p.PersonalNumber.ToLower().Contains(request.PersonalNumber.ToLower()), cancellationToken);

            return new DataResponse<IEnumerable<Person>>
            {
                Data = persons
            };
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;
        
        #endregion
    }
}
