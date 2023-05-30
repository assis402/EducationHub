using EducationHub.Shared.Dtos.Course;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Validators.Course
{
    public class CourseDeleteDtoValidator : AbstractValidator<CourseDeleteDto>
    {
        public CourseDeleteDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();
        }
    }
}
