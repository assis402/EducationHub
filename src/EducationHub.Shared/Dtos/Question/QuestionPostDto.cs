namespace EducationHub.Shared.Dtos.Question
{
    public class QuestionPostDto : BaseDto
    {
        public string CourseId { get; init; }

        public string Text { get; init; }

        public char CorrectAlternative { get; init; }

        public IEnumerable<QuestionAlternativeDto> Alternatives { get; init; }
    }
}