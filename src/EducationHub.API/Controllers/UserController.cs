using EducationHub.API.Dtos;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(ITokenService tokenService, 
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginDto loginDto)
        {
            var token = await _userService.Login(loginDto);

            if (token is null) return NotFound();

            return new
            {
                token
            };
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<dynamic>> SignUpAsync([FromBody] SignUpDto signUpDto)
        {
            await _userService.SignUp(signUpDto);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("test")]
        public async Task<ActionResult<dynamic>> Test()
        {
            return "test";
        }

        [HttpGet]
        [Authorize(Roles = "manager")]
        [Route("test2")]
        public async Task<ActionResult<dynamic>> Test2()
        {
            return "test";
        }
    }
}