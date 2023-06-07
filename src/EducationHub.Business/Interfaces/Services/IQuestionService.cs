using ApiResults;
using EducationHub.Shared.Dtos.Question;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IQuestionService
    {
        public Task<ApiResult> Insert(QuestionPostDto coursePostDto);

        public Task<ApiResult> Update(QuestionPutDto coursePutDto);

        public Task<ApiResult> Delete(string id);

        public Task<ApiResult> GetAllByCourseId(string courseId);
    }
}