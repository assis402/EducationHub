using ApiResults.Helpers;
using EducationHub.Business.Enums;
using EducationHub.Business.Messages;
using EducationHub.Shared.Dtos.Course;
using FluentValidation;
using static EducationHub.Shared.Helpers.Utils;

namespace EducationHub.Business.Validators.Course
{
    public class CoursePutDtoValidator : AbstractValidator<CoursePutDto>
    {
        public CoursePutDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Status)
                .Must(ValidateEnum<CourseStatus>)
                .WithMessage(EducationHubErrors.CourseUpdate_Validation_InvalidStatus.Description());
        }
    }
}