namespace EducationHub.Shared.Dtos.Course
{
    public class CourseResponseDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ProfessorId { get; set; }

        public int WorkLoad { get; set; }

        public int TotalRegistrations { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}