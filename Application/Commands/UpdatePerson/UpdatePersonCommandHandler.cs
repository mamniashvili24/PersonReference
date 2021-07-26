using System;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.CQRS.Commands;
using Application.Commands.UpdatePersonCity;
using Application.Commands.UpdatePersonGender;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public UpdatePersonCommandHandler(IUnitOfWork unitOfWork, ICommandBus commandBus)
        {
            _unitOfWork = unitOfWork;
            _commandBus = commandBus;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
        {
            var person = _unitOfWork.PersonRepository.GetById(command.Id);
            if (person == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "Person.ByThisId.NotExist"
                };
            }

            var result = await _commandBus.Send(new UpdatePersonGenderCommand
            {
                GenderName = command.GenderName,
                PersonId = command.Id
            });

            if (result.IsError)
            {
                return result;
            }

            result = await _commandBus.Send(new UpdatePersonCityCommand
            {
                CityId = command.CityId,
                PersonId = command.Id
            });

            if (result.IsError)
            {
                return result;
            }

            PreparePerson(person, command);
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        #endregion

        #region [ Private Method(s) ]

        private void PreparePerson(Person person, UpdatePersonCommand command)
        {
            person.Birthday = command.Birthday;
            person.LastName = command.LastName;
            person.FirstName = command.FirstName;
            person.PhoneNumber = command.PhoneNumber;
            person.PersonalNumber = command.PersonalNumber;
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandBus _commandBus;

        #endregion
    }
}