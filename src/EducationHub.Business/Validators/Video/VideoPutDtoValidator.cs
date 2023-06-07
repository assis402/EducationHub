using EducationHub.Shared.Dtos.Video;
using FluentValidation;

namespace EducationHub.Business.Validators.Video
{
    public class VideoPutDtoValidator : AbstractValidator<VideoPutDto>
    {
        public VideoPutDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CourseId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();
        }
    }
}