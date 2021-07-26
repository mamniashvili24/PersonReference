using FluentValidation;

namespace Application.Commands.UploadPicture
{
    public class UploadUpdatePictureCommandValidator : AbstractValidator<UploadOrUpdatePictureCommand>
    {
        public UploadUpdatePictureCommandValidator()
        {
            RuleFor(o => o.PersonId).GreaterThan(0).WithMessage("Model.Invalid.PersonId");
            RuleFor(o => o.File).NotNull().WithMessage("Model.Invalid.File");
        }
    }
}