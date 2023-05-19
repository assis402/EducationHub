using ApiResults;
using EducationHub.Business.Messages;
using EducationHub.Shared.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
