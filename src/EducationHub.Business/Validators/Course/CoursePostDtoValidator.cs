using EducationHub.Business.Messages;
using EducationHub.Shared.Dtos.Course;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Validators.Course
{
    public class CoursePostDtoValidator : AbstractValidator<CoursePostDto>
    {
        public CoursePostDtoValidator()
        {
            RuleFor(x => x.Title)
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
