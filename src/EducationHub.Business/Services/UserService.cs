using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Business.Validators.User;
using EducationHub.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using System.Net;

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

        public async Task<ApiResult> Login(LoginDto loginDto)
        {
            var validation = new LoginDtoValidator().Validate(loginDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest, 
                    validation.Errors);

            var user = new User(loginDto);
            var result = await _repository.FindOneAsync(user.LoginFilterDefinition());

            if (result is null)
                return Result.Error(
                    EducationHubErrors.Login_Error_WrongEmailOrPassword, 
                    HttpStatusCode.NotFound);

            var token = _tokenService.GenerateToken(result);

            return Result.Success(
                EducationHubMessages.Login_Success, 
                statusCode: HttpStatusCode.OK,
                responseData: new { Token = token });
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