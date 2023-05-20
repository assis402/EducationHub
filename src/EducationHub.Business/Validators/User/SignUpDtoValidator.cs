using ApiResults.Helpers;
using EducationHub.Business.Messages;
using EducationHub.Shared.Dtos;
using FluentValidation;

namespace EducationHub.Business.Validators.User
{
    public class SignUpDtoValidator : AbstractValidator<SignUpDto>
    {
        public SignUpDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage(EducationHubErrors.Login_Validation_InvalidEmail.Description());

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}