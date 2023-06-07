using EducationHub.API.CustomAttributes;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CourseGetByFilterDto courseGetByFilterDto)
        {
            courseGetByFilterDto.SetUserId(User);
            var result = await _courseService.GetAllByFilter(courseGetByFilterDto);
            return result.Convert();
        }

        [HttpPost]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Insert(CoursePostDto coursePostDto)
        {
            coursePostDto.SetUserId(User);
            var result = await _courseService.Insert(coursePostDto);
            return result.Convert();
        }

        [HttpPut]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Put(CoursePutDto coursePutDto)
        {
            coursePutDto.SetUserId(User);
            var result = await _courseService.Update(coursePutDto);
            return result.Convert();
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _courseService.Delete(new DeleteDto(id, User));
            return result.Convert();
        }
    }
}