namespace EducationHub.Shared.Dtos.Course
{
    public class CourseDeleteDto : BaseDto
    {
        public string Id { get; set; }

        public static implicit operator CourseDeleteDto(string id)
        {
            return new() { Id = id };
        }
    }
}