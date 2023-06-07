using EducationHub.Shared.Dtos.CourseSection;
using EducationHub.Shared.Helpers;
using MongoDB.Driver;

namespace EducationHub.Business.Entities
{
    public class CourseSection : BaseEntity
    {
        public CourseSection(CourseSectionPostDto courseSectionDto)
        {
            Title = courseSectionDto.Title;
            CourseId = courseSectionDto.CourseId;
        }

        public static implicit operator CourseSectionResponseDto(CourseSection course)
        {
            return new CourseSectionResponseDto
            {
                Id = course.Id.ToString(),
                Title = course.Title,
                CourseId = course.CourseId,
                CreatedDate = course.CreatedDate,
                UpdateDate = course.UpdateDate
            };
        }

        public string Title { get; set; }

        public string CourseId { get; set; }

        public void Update(CourseSectionPutDto courseSectionPutDto)
        {
            Title = courseSectionPutDto.Title;
        }

        public UpdateDefinition<CourseSection> UpdateDefinition()
            => Builders<CourseSection>.Update.Set(nameof(Title).FirstCharToLowerCase(), Title);

        public static FilterDefinition<CourseSection> SameTitleFilterDefinition(string title, string courseId)
            => Builders<CourseSection>.Filter.Where(x =>
                x.Title.Equals(title) &&
                x.CourseId.Equals(courseId));

        public static FilterDefinition<CourseSection> SameIdFilterDefinition(string id)
            => Builders<CourseSection>.Filter.Where(x => x.Id.ToString().Equals(id));
    }
}