namespace EducationHub.Shared.Dtos.CourseSection
{
    public class CourseSectionResponseDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string CourseId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}