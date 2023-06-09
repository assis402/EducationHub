﻿using EducationHub.Shared.Dtos.Course;
using FluentValidation;

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