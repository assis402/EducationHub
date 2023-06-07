namespace EducationHub.Business.Entities
{
    public class Video : BaseEntity
    {
        public string CourseId { get; set; }

        public string SectionId { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public IEnumerable<VideoAttachment> Attachments { get; set; }
    }

    public class VideoAttachment
    {
        public string Title { get; set; }

        public string Url { get; set; }
    }
}