using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Business.Validators;
using EducationHub.Business.Validators.Course;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.CourseSection;

namespace EducationHub.Business.Services
{
    public class CourseSectionService : ICourseSectionService
    {
        private readonly IBaseRepository<CourseSection> _repository;
        private readonly ICourseService _courseService;

        public CourseSectionService(IBaseRepository<CourseSection> repository,
            ICourseService courseService)
        {
            _repository = repository;
            _courseService = courseService;
        }

        public async Task<ApiResult> Insert(CourseSectionPostDto courseSectionPostDto)
        {
            var validation = new CourseSectionPostDtoValidator().Validate(courseSectionPostDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var exists = await _repository.Exists(CourseSection.SameTitleFilterDefinition(courseSectionPostDto.Title, courseSectionPostDto.CourseId));

            if (exists)
                return Result.Error(EducationHubErrors.CourseInsert_Error_AlreadyExists);

            var courseSection = new CourseSection(courseSectionPostDto);
            await _repository.InsertOneAsync(courseSection);

            return Result.Success(EducationHubMessages.Insert_Success, (CourseSectionResponseDto)courseSection);
        }

        public async Task<ApiResult> Update(CourseSectionPutDto courseSectionPutDto)
        {
            var validation = new CourseSectionPutDtoValidator().Validate(courseSectionPutDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var existentCourseSection = await _repository.FindOneAsync(CourseSection.SameIdFilterDefinition(courseSectionPutDto.Id));

            if (existentCourseSection is null)
                return Result.Error(EducationHubErrors.Error_NotFound);

            var getCourseByIdResult = await _courseService.GetById(existentCourseSection.CourseId);

            if (!getCourseByIdResult.Success)
                return getCourseByIdResult;

            Course existentCourse = getCourseByIdResult.Data;

            if (!courseSectionPutDto.UserId.Equals(existentCourse.ProfessorId))
                return Result.Error(EducationHubErrors.CourseDelete_Error_Forbidden);

            var existsWithSameTitle = await _repository.Exists(CourseSection.SameTitleFilterDefinition(courseSectionPutDto.Title, courseSectionPutDto.Id));

            if (existsWithSameTitle)
                return Result.Error(EducationHubErrors.CourseInsert_Error_AlreadyExists);

            existentCourseSection.Update(courseSectionPutDto);
            await _repository.UpdateOneAsync(existentCourseSection, existentCourseSection.UpdateDefinition());

            return Result.Success(EducationHubMessages.Update_Success, existentCourseSection);
        }

        public async Task<ApiResult> Delete(DeleteDto courseSectionDeleteDto)
        {
            var validation = new DeleteDtoValidator().Validate(courseSectionDeleteDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var existentCourseSection = await _repository.FindOneAsync(CourseSection.SameIdFilterDefinition(courseSectionDeleteDto.Id));

            if (existentCourseSection is null)
                return Result.Error(EducationHubErrors.Error_NotFound);

            var getCourseByIdResult = await _courseService.GetById(existentCourseSection.CourseId);

            if (!getCourseByIdResult.Success)
                return getCourseByIdResult;

            Course existentCourse = getCourseByIdResult.Data;

            if (!courseSectionDeleteDto.UserId.Equals(existentCourse.ProfessorId))
                return Result.Error(EducationHubErrors.CourseDelete_Error_Forbidden);

            await _repository.DeleteOneAsync(courseSectionDeleteDto.Id);

            return Result.Success(EducationHubMessages.Delete_Success);
        }

        public async Task<ApiResult> GetAllByCourseId(string courseId)
        {
            throw new NotImplementedException();
        }
    }
}