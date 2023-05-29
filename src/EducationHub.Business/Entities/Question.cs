namespace EducationHub.Business.Entities
{
    public class Question : BaseEntity
    {
        public string CourseId { get; set; }

        public string Text { get; set; }

        public char CorrectAlternative { get; set; }

        public IEnumerable<QuestionAlternative> Alternatives { get; set; }
    }

    public class QuestionAlternative
    {
        public char Letter { get; set; }

        public string Text { get; set; }
    }
}