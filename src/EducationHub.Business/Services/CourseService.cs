using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Business.Validators;
using EducationHub.Business.Validators.Course;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.Course;
using EducationHub.Shared.Helpers;
using MongoDB.Driver;

namespace EducationHub.Business.Services
{
    public class CourseService : ICourseService
    {
        private readonly IBaseRepository<Course> _repository;

        public CourseService(IBaseRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<ApiResult> GetAllByFilter(CourseGetByFilterDto courseGetByFilterDto)
        {
            FilterDefinition<Course> filterDefinition;

            if (courseGetByFilterDto.Title.IsNotNullAndNotEmpty())
                filterDefinition = Course.SearchFilterDefinition(courseGetByFilterDto);
            else
                filterDefinition = Course.GetAllFilterDefinition();

            var result = await _repository.FindAsync(filterDefinition);

            return Result.Success(result.Select(x => (CourseResponseDto)x));
        }

        public async Task<ApiResult> Delete(DeleteDto courseDeleteDto)
        {
            var validation = new DeleteDtoValidator().Validate(courseDeleteDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var existentCourse = await _repository.FindOneAsync(Course.SameIdFilterDefinition(courseDeleteDto.Id));

            if (existentCourse is null)
                return Result.Error(EducationHubErrors.Error_NotFound);

            if (!courseDeleteDto.UserId.Equals(existentCourse.ProfessorId))
                return Result.Error(EducationHubErrors.CourseDelete_Error_Forbidden);

            await _repository.DeleteOneAsync(courseDeleteDto.Id);

            return Result.Success(EducationHubMessages.Delete_Success);
        }

        public async Task<ApiResult> Insert(CoursePostDto coursePostDto)
        {
            var validation = new CoursePostDtoValidator().Validate(coursePostDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var exists = await _repository.Exists(Course.SameTitleFilterDefinition(coursePostDto.Title));

            if (exists)
                return Result.Error(EducationHubErrors.CourseInsert_Error_AlreadyExists);

            var course = new Course(coursePostDto);
            await _repository.InsertOneAsync(course);

            return Result.Success(EducationHubMessages.Insert_Success, (CourseResponseDto)course);
        }

        public async Task<ApiResult> Update(CoursePutDto coursePutDto)
        {
            var validation = new CoursePutDtoValidator().Validate(coursePutDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var existentCourse = await _repository.FindOneAsync(Course.SameIdFilterDefinition(coursePutDto.Id));

            if (existentCourse is null)
                return Result.Error(EducationHubErrors.Error_NotFound);

            if (!coursePutDto.UserId.Equals(existentCourse.ProfessorId))
                return Result.Error(EducationHubErrors.CourseUpdate_Error_Forbidden);

            var existsWithSameTitle = await _repository.Exists(Course.SameTitleFilterDefinition(coursePutDto.Title, coursePutDto.Id));

            if (existsWithSameTitle)
                return Result.Error(EducationHubErrors.CourseInsert_Error_AlreadyExists);

            existentCourse.Update(coursePutDto);
            await _repository.UpdateOneAsync(existentCourse, existentCourse.UpdateDefinition());

            return Result.Success(EducationHubMessages.Update_Success, existentCourse);
        }

        public async Task<ApiResult> GetById(string courseId)
        {
            var existentCourse = await _repository.FindOneAsync(Course.SameIdFilterDefinition(courseId));

            if (existentCourse is null)
                return Result.Error(EducationHubErrors.Error_NotFound);

            return Result.Success(existentCourse);
        }
    }
}