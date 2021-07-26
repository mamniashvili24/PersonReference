using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public DeletePersonCommandHandler(IUnitOfWork unitOfWorck)
        {
            _unitOfWorck = unitOfWorck;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse> Handle(DeletePersonCommand command, CancellationToken cancellationToken)
        {
            var person = _unitOfWorck.PersonRepository.GetById(command.Id);
            if (person == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "Person.ByThisId.NotExist"
                };
            }

            var relatedPersons = await _unitOfWorck.RelatedPersonRepository.WhereAsync(x => x.Person.Id == command.Id || x.RelatedPerson.Id == command.Id, cancellationToken);
            
            if (relatedPersons != null && relatedPersons.Any())
            {
                _unitOfWorck.RelatedPersonRepository.Delete(relatedPersons);
            }
            _unitOfWorck.PersonRepository.Delete(person);

            await _unitOfWorck.SaveChangesAsync();

            return new DataResponse();
        }
        
        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWorck;

        #endregion
    }
}