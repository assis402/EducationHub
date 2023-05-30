using EducationHub.API.CustomAttributes;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Validators.User;
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
        public string Get()
        {
            return
        }

        [HttpPost]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Insert(CoursePostDto courseDto)
        {
            courseDto.SetUserId(User);
            var result = await _courseService.Insert(courseDto);
            return result.Convert();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}