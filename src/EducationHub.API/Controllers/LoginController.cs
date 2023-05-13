using EducationHub.Application.Interfaces;
using EducationHub.Business.Entities;
using EducationHub.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationHub.API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null) 
                return NotFound();

            var token = _tokenService.GenerateToken(user);

            return new
            {
                token
            };
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
        [Route("test")]
        public async Task<ActionResult<dynamic>> Test2()
        {
            return "test";
        }
    }
}
