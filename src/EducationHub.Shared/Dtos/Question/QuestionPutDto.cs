namespace EducationHub.Shared.Dtos.Question
{
    public class QuestionPostDto
    {
        public string Id { get; init; }

        public string CourseId { get; init; }

        public string Text { get; init; }

        public char CorrectAlternative { get; init; }

        public IEnumerable<QuestionAlternativeDto> Alternatives { get; init; }
    }

    public class QuestionAlternativeDto
    {
        public char Letter { get; init; }

        public string Text { get; init; }
    }
}