using EducationHub.API.Dtos;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IUserService
    {
        public Task<string> Login(LoginDto loginDto);

        public Task SignUp(SignUpDto signUpDto);
    }
}