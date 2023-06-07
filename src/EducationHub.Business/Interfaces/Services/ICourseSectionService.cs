using ApiResults;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.CourseSection;

namespace EducationHub.Business.Interfaces.Services
{
    public interface ICourseSectionService
    {
        public Task<ApiResult> Insert(CourseSectionPostDto courseSectionPostDto);

        public Task<ApiResult> Update(CourseSectionPutDto courseSectionPutDto);

        public Task<ApiResult> Delete(DeleteDto courseSectionDeleteDto);

        public Task<ApiResult> GetAllByCourseId(string courseId);
    }
}