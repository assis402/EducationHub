using EducationHub.API.CustomAttributes;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.CourseSection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseSectionController : ControllerBase
    {
        private readonly ICourseSectionService _courseSectionService;

        public CourseSectionController(ICourseSectionService courseSectionService)
        {
            _courseSectionService = courseSectionService;
        }

        [HttpPost]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Insert(CourseSectionPostDto courseSectionPostDto)
        {
            courseSectionPostDto.SetUserId(User);
            var result = await _courseSectionService.Insert(courseSectionPostDto);
            return result.Convert();
        }

        [HttpPut]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Put(CourseSectionPutDto courseSectionPutDto)
        {
            courseSectionPutDto.SetUserId(User);
            var result = await _courseSectionService.Update(courseSectionPutDto);
            return result.Convert();
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _courseSectionService.Delete(new DeleteDto(id, User));
            return result.Convert();
        }
    }
}