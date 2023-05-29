using EducationHub.Shared.Dtos;
using FluentValidation;

namespace EducationHub.Business.Validators.User
{
    public class ConfirmAccountDtoValidator : AbstractValidator<ConfirmAccountDto>
    {
        public ConfirmAccountDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Token)
                .NotEmpty()
                .NotNull();
        }
    }
}