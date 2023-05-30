using ApiResults.Helpers;
using EducationHub.Business.Messages;
using EducationHub.Shared.Dtos.User;
using FluentValidation;

namespace EducationHub.Business.Validators.User
{
    public class InviteDtoValidator : AbstractValidator<InviteProfessorDto>
    {
        public InviteDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage(EducationHubErrors.Login_Validation_InvalidEmail.Description());
        }
    }
}