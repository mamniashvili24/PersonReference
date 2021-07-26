using System;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.AddRelatedPerson
{
    public class AddRelatedPersonHandler : ICommandHandler<AddRelatedPersonCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public AddRelatedPersonHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse> Handle(AddRelatedPersonCommand command, CancellationToken cancellationToken)
        {
            var person = _unitOfWork.PersonRepository.GetById(command.PersonId);
            if (person == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "Person.ByThisId.NotExist"
                };
            }

            var relatedPerson = _unitOfWork.PersonRepository.GetById(command.RelatedPersonId);
            if (person == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "RelatedPerson.ByThisId.NotExist"
                };
            }

            var relatedPersonType = await _unitOfWork.RelatedPersonTypeRepository.FirstOrDefaultAsync(x => x.Type.ToLower() == command.RelatedPersonType.ToLower(), cancellationToken);
            if (relatedPersonType == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "RelatedPerson.ByThisType.NotExist"
                };
            }

            await _unitOfWork.RelatedPersonRepository.InsertAsync(new PersonRelatedPerson
            {
                Person = person,
                RelatedPerson = relatedPerson,
                RelatedPersonType = relatedPersonType
            }, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return new DataResponse();
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion
    }
}