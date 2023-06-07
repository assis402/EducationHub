namespace EducationHub.Shared.Dtos.Video
{
    public class VideoPostDto : BaseDto
    {
        public string Title { get; init; }

        public string CourseId { get; init; }

        public string Url { get; init; }

        public string Description { get; init; }
    }
}