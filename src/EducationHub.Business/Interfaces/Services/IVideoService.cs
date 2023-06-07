using ApiResults;
using EducationHub.Shared.Dtos.Video;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IVideoService
    {
        public Task<ApiResult> Insert(VideoPostDto videoPostDto);

        public Task<ApiResult> Update(VideoPutDto videoPutDto);

        public Task<ApiResult> Delete(string id);

        public Task<ApiResult> GetAllByCourseId(string courseId);
    }
}