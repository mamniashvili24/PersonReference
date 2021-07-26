using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.UpdatePersonCity
{
    public class UpdatePersonCityCommandHandler : ICommandHandler<UpdatePersonCityCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public UpdatePersonCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse> Handle(UpdatePersonCityCommand command, CancellationToken cancellationToken)
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

            if (person?.City?.Id == command?.CityId)
            {
                return new DataResponse();
            }

            var city = _unitOfWork.CityRepository.GetById(command.CityId);

            if (city == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "City.ByThisId.NotExist"
                };
            }

            person.City = city;
            await _unitOfWork.SaveChangesAsync();

            return new DataResponse();
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion
    }
}