using EducationHub.API.CustomAttributes;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Dtos.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Insert(VideoPostDto videoPostDto)
        {
            videoPostDto.SetUserId(User);
            var result = await _videoService.Insert(videoPostDto);
            return result.Convert();
        }

        [HttpPut]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Put(VideoPutDto videoPutDto)
        {
            videoPutDto.SetUserId(User);
            var result = await _videoService.Update(videoPutDto);
            return result.Convert();
        }

        [HttpDelete("{id}")]
        [AuthorizeRoles(UserRole.Admin, UserRole.Professor)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _videoService.Delete(new DeleteDto(id, User));
            return result.Convert();
        }
    }
}