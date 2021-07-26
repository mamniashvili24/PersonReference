using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.UpdatePersonGender
{
    public class UpdatePersonGenderCommandHandler : ICommandHandler<UpdatePersonGenderCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public UpdatePersonGenderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task<IDataResponse> Handle(UpdatePersonGenderCommand command, CancellationToken cancellationToken)
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

            if (person?.Gender?.GenderName.ToLower() == command?.GenderName.ToLower())
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
            await _unitOfWork.SaveChangesAsync();

            return new DataResponse();
        }

        #endregion

        #region [ Constructor(s) ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion
    }
}