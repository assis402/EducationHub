using ApiResults.Helpers;
using EducationHub.Business.Enums;
using EducationHub.Business.Messages;
using FluentValidation;

namespace EducationHub.Business.Validators.User
{
    public class UserValidator : AbstractValidator<Entities.User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Status)
                .NotEqual(UserStatus.UnconfirmedAccount)
                .WithMessage(EducationHubErrors.User_Validation_UncomfirmedAccount.Description());

            RuleFor(x => x.Status)
                .NotEqual(UserStatus.Blocked)
                .WithMessage(EducationHubErrors.User_Validation_Blocked.Description());
        }
    }
}