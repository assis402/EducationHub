using EducationHub.Business.Interfaces.Services;
using EducationHub.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] LoginDto loginDto)
        {
            var result = await _userService.Login(loginDto);
            return result.Convert();
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto signUpDto)
        {
            var result = await _userService.SignUp(signUpDto);
            return result.Convert();
        }

        [HttpGet]
        [Route("confirmAccount")]
        public async Task<IActionResult> ConfirmAccount([FromQuery] string data)
        {
            var result = await _userService.ConfirmAccount(data);
            return result.Convert();
        }

        //[HttpGet]
        //[Authorize]
        //[Route("test")]
        //public async Task<ActionResult<dynamic>> Test()
        //{
        //    return "test";
        //}

        //[HttpGet]
        //[Authorize(Roles = "manager")]
        //[Route("test2")]
        //public async Task<ActionResult<dynamic>> Test2()
        //{
        //    return "test";
        //}
    }
}