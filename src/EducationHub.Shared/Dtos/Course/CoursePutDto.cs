namespace EducationHub.Shared.Dtos.Course
{
    public class CoursePutDto : BaseDto
    {
        public string Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public string Status { get; init; }
    }
}