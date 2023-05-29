namespace EducationHub.Shared.Dtos
{
    public class CourseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ProfessorId { get; set; }

        public void SetProfessorId()
        {
        }
    }
}