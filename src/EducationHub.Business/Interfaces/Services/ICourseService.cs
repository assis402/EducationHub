using ApiResults;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.Course;

namespace EducationHub.Business.Interfaces.Services
{
    public interface ICourseService
    {
        public Task<ApiResult> Insert(CoursePostDto coursePostDto);

        public Task<ApiResult> Update(CoursePutDto coursePutDto);

        public Task<ApiResult> Delete(DeleteDto courseDeleteDto);

        public Task<ApiResult> GetAllByFilter(CourseGetByFilterDto courseGetByFilterDto);

        public Task<ApiResult> GetById(string courseId);
    }
}