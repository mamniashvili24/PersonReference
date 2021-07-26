using System;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Mapping;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.AddPerson
{
    public class AddRelatedPersonHandler : ICommandHandler<AddPersonCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public AddRelatedPersonHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse> Handle(AddPersonCommand command, CancellationToken cancellationToken)
        {
            var person = Mapping.Map<AddPersonCommand, Person>(command);

            var result = await PrepareGenderAsync(command, person, cancellationToken);
            if (result.IsError)
            {
                return result;
            }

            result = PrepareCity(command, person, cancellationToken);
            if (result.IsError)
            {
                return result;
            }

            await _unitOfWork.PersonRepository.InsertAsync(person, cancellationToken);

            result = await PrepareRelatedPersonAsync(command, person, cancellationToken);
            if (result.IsError)
            {
                return result;
            }

            await _unitOfWork.SaveChangesAsync();
            return new DataResponse();
        }

        #endregion

        #region [ Private Method(s) ]

        private DataResponse PrepareCity(AddPersonCommand command, Person person, CancellationToken cancellationToken)
        {
            if (command.CityId <= 0)
            {
                return new DataResponse();
            }

            var city = _unitOfWork.CityRepository.GetById(command.CityId, cancellationToken);

            if (city == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "City.ByThisId.NotExist"
                };
            }

            person.City = city;
            return new DataResponse();
        }
        private async Task<DataResponse> PrepareRelatedPersonAsync(AddPersonCommand command, Person person, CancellationToken cancellationToken)
        {
            if (command.RelatedPersonId <= 0)
            {
                return new DataResponse();
            }

            var relatedPerson = _unitOfWork.PersonRepository.GetById(command.RelatedPersonId, cancellationToken);

            if (relatedPerson == null)
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
            return new DataResponse();
        }
        private async Task<DataResponse> PrepareGenderAsync(AddPersonCommand command, Person person, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.GenderName))
            {
                return new DataResponse();
            }

            var gender = await _unitOfWork.GenderRepository.FirstOrDefaultAsync(g => g.GenderName.ToLower() == command.GenderName.ToLower(), cancellationToken);

            if (gender == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "Gender.ByThisName.NotExist"
                };
            }

            person.Gender = gender;
            return new DataResponse();
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion
    }
}