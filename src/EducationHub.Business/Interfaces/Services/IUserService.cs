using ApiResults;
using EducationHub.Shared.Dtos;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ApiResult> Login(LoginDto loginDto);

        public Task<ApiResult> SignUp(SignUpDto signUpDto);

        public Task<ApiResult> ConfirmAccount(string encriptedData);
    }
}