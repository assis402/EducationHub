using EducationHub.Shared.Dtos;
using FluentValidation;

namespace EducationHub.Business.Validators
{
    public class DeleteDtoValidator : AbstractValidator<DeleteDto>
    {
        public DeleteDtoValidator()
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