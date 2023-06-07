using EducationHub.Shared.Dtos.Video;
using FluentValidation;

namespace EducationHub.Business.Validators.Video
{
    public class VideoPostDtoValidator : AbstractValidator<VideoPostDto>
    {
        public VideoPostDtoValidator()
        {
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