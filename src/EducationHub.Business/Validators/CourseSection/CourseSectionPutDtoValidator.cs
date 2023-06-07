using EducationHub.Shared.Dtos.CourseSection;
using FluentValidation;

namespace EducationHub.Business.Validators.Course
{
    public class CourseSectionPutDtoValidator : AbstractValidator<CourseSectionPutDto>
    {
        public CourseSectionPutDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();
        }
    }
}