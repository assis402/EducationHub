using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Shared.Dtos;
using Microsoft.AspNetCore.Http;

namespace EducationHub.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        private readonly ITokenService _tokenService;

        public UserService(IBaseRepository<User> repository, 
            ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = new User(loginDto);
            var result = await _repository.FindOneAsync(user.LoginFilterDefinition());

            if (result is null) return null;

            return _tokenService.GenerateToken(result);
        }

        public async Task<ApiResult> SignUp(SignUpDto signUpDto)
        {
            var user = new User(signUpDto);
            var existsUser = await _repository.FindOneAsync(user.FindByEmailOrUsernameFilterDefinition());

            if (existsUser is not null) 
                return Result.Error(EducationHubErrors.SignUp_Error_UserAlreadyExists);

            await _repository.InsertOneAsync(user);
            return Result.Success(EducationHubMessages.SignUp_Success);
        }
    }
}