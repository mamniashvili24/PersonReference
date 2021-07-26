using System;
using System.IO;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Commands.UploadPicture
{
    public class UploadOrUpdatePictureCommandHandler : ICommandHandler<UploadOrUpdatePictureCommand, IDataResponse>
    {
        #region [ Constructor(s) ]

        public UploadOrUpdatePictureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion
        
        #region [ Public Method(s) ]
        
        public async Task<IDataResponse> Handle(UploadOrUpdatePictureCommand request, CancellationToken cancellationToken)
        {
            var person = _unitOfWork.PersonRepository.GetById(request.PersonId);
            if (person == null)
            {
                return new DataResponse
                {
                    IsError = true,
                    Message = "Person.ByThisId.NotExist"
                };
            }

            if (!string.IsNullOrEmpty(person.ImageUrl))
            {
                DeleteImage(person.ImageUrl);
            }

            var imagePath = await UploadImageAsync(request.File);

            await UpdatePersonAsync(person, imagePath);

            return new DataResponse();
        }

        #endregion
        
        #region [ Private Method(s) ]

        private async Task UpdatePersonAsync(Person person, string imagePath)
        {
            person.ImageUrl = imagePath;
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();
        }
        private async Task<string> UploadImageAsync(IFormFile image)
        {
            var filePath = string.Empty;
            var wwwRootPath = Environment.CurrentDirectory + "/Images";
            if (!Directory.Exists(wwwRootPath))
            {
                Directory.CreateDirectory(wwwRootPath);
            }
            var fileName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(image.FileName);
            var imageName = fileName = fileName + extension;
            var path = Path.Combine(wwwRootPath, fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            filePath = $"/Images/{imageName}";

            return filePath;
        }
        private void DeleteImage(string imageUrl)
        {
            var wwwRootPath = Environment.CurrentDirectory + imageUrl;

            if (File.Exists(wwwRootPath))
            {
                File.Delete(wwwRootPath);
            }
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IUnitOfWork _unitOfWork;

        #endregion
    }
}