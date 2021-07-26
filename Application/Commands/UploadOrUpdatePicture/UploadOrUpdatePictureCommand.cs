using Microsoft.AspNetCore.Http;
using Infrastructure.CQRS.Commands;
using Infrastructure.CommonTypes.Abstractions;

namespace Application.Commands.UploadPicture
{
    public class UploadOrUpdatePictureCommand : ICommand<IDataResponse>
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }
    }
}