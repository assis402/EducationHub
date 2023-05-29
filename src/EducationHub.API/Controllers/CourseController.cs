using EducationHub.API.CustomAttributes;
using EducationHub.Business.Enums;
using EducationHub.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return
        }

        [HttpPost]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public void Insert(CourseDto courseDto)
        {
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