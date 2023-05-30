using EducationHub.Shared.Dtos.Course;
using EducationHub.Shared.Dtos.User;
using EducationHub.Shared.Helpers;
using MongoDB.Driver;

namespace EducationHub.Business.Entities
{
    public class Course : BaseEntity
    {
        public Course(CoursePostDto courseDto)
        {
            Title = courseDto.Title;
            Description = courseDto.Description;
            ProfessorId = courseDto.UserId;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ProfessorId { get; set; }

        public int WorkLoad { get; set; }

        public int TotalRegistrations { get; set; }

        //TODO: AVALIACAO, COMENTARIOS

        public void Update(CoursePutDto coursePutDto)
        {
            Title = coursePutDto.Title;
            Description = coursePutDto.Description;
        }

        public UpdateDefinition<Course> UpdateDefinition()
            => Builders<Course>.Update.Set(nameof(Title).FirstCharToLowerCase(), Title)
                                      .Set(nameof(Description).FirstCharToLowerCase(), Description);

        public static FilterDefinition<Course> SameTitleFilterDefinition(string title)
            => Builders<Course>.Filter.Where(x => x.Title.Equals(title));

        public static FilterDefinition<Course> SameIdFilterDefinition(string id)
            => Builders<Course>.Filter.Where(x => x.Id.ToString().Equals(id));
    }
}