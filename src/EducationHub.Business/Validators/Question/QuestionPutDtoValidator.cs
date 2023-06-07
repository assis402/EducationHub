using ApiResults.Helpers;
using EducationHub.Business.Messages;
using EducationHub.Shared.Dtos.Question;
using FluentValidation;

namespace EducationHub.Business.Validators.Question
{
    public class QuestionPutDtoValidator : AbstractValidator<QuestionPutDto>
    {
        public QuestionPutDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CourseId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CorrectAlternative)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Alternatives)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Alternatives)
                .Must(x => x.Count() == 4)
                .WithMessage(EducationHubErrors.Question_Error_Validation.Description());
        }
    }
}