using EducationHub.Business.Enums;
using EducationHub.Shared.Dtos.Course;
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
            Status = CourseStatus.Inactive;
        }

        public static implicit operator CourseResponseDto(Course course)
        {
            return new CourseResponseDto
            {
                Id = course.Id.ToString(),
                Title = course.Title,
                Description = course.Description,
                ProfessorId = course.ProfessorId,
                TotalRegistrations = course.TotalRegistrations,
                WorkLoad = course.WorkLoad,
                CreatedDate = course.CreatedDate,
                UpdateDate = course.UpdateDate
            };
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ProfessorId { get; set; }

        public int WorkLoad { get; set; }

        public int TotalRegistrations { get; set; }

        public CourseStatus Status { get; set; }

        //TODO: CATEGORIA, AVALIACAO, COMENTARIOS

        public void Update(CoursePutDto coursePutDto)
        {
            Title = coursePutDto.Title;
            Description = coursePutDto.Description;
            Status = Enum.Parse<CourseStatus>(coursePutDto.Status, true);
        }

        public UpdateDefinition<Course> UpdateDefinition()
            => Builders<Course>.Update.Set(nameof(Title).FirstCharToLowerCase(), Title)
                                      .Set(nameof(Description).FirstCharToLowerCase(), Description)
                                      .Set(nameof(Status).FirstCharToLowerCase(), Status);

        public static FilterDefinition<Course> SameTitleFilterDefinition(string title)
            => Builders<Course>.Filter.Where(x => x.Title.Equals(title));

        public static FilterDefinition<Course> SameTitleFilterDefinition(string title, string id)
            => Builders<Course>.Filter.Where(x =>
                x.Title.Equals(title) &&
                !x.Id.ToString().Equals(id));

        public static FilterDefinition<Course> SameIdFilterDefinition(string id)
            => Builders<Course>.Filter.Where(x => x.Id.ToString().Equals(id));

        public static FilterDefinition<Course> SearchFilterDefinition(CourseGetByFilterDto courseGetByFilterDto)
            => Builders<Course>.Filter.Where(x =>
                x.Title.ToLower().Contains(courseGetByFilterDto.Title.ToLower()) &&
                x.Status.Equals(UserStatus.Active));

        public static FilterDefinition<Course> GetAllFilterDefinition()
            => Builders<Course>.Filter.Where(x => x.Status.Equals(UserStatus.Active));
    }
}