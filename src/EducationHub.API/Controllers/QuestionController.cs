using EducationHub.API.CustomAttributes;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] QuestionGetByFilterDto questionGetByFilterDto)
        //{
        //    questionGetByFilterDto.SetUserId(User);
        //    var result = await _questionService.GetAllByFilter(questionGetByFilterDto);
        //    return result.Convert();
        //}

        [HttpPost]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Insert(QuestionPostDto questionPostDto)
        {
            questionPostDto.SetUserId(User);
            var result = await _questionService.Insert(questionPostDto);
            return result.Convert();
        }

        [HttpPut]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Put(QuestionPutDto questionPutDto)
        {
            questionPutDto.SetUserId(User);
            var result = await _questionService.Update(questionPutDto);
            return result.Convert();
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _questionService.Delete(new DeleteDto(id, User));
            return result.Convert();
        }
    }
}