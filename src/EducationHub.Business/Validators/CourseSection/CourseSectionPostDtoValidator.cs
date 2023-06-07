using EducationHub.Shared.Dtos.CourseSection;
using FluentValidation;

namespace EducationHub.Business.Validators.Course
{
    public class CourseSectionPostDtoValidator : AbstractValidator<CourseSectionPostDto>
    {
        public CourseSectionPostDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();
        }
    }
}