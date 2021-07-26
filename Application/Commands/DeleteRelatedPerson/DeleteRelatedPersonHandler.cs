using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonHandler : ICommandHandler<DeleteRelatedPersonCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public DeleteRelatedPersonHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse> Handle(DeleteRelatedPersonCommand command, CancellationToken cancellationToken)
        {
            var personRelatedPerson = await _unitOfWork.RelatedPersonRepository.FirstOrDefaultAsync(x => x.Person.Id == command.PersonId && x.RelatedPerson.Id == command.RelatedPersonId, cancellationToken);
            if (personRelatedPerson == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "RelatedPerson.ByThisId.NotExist"
                };
            }

            _unitOfWork.RelatedPersonRepository.Delete(personRelatedPerson);
            await _unitOfWork.SaveChangesAsync();

            return new DataResponse();
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion
    }
}