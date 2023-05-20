using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Business.Validators.User;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Helpers;
using System.Net;

namespace EducationHub.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        public UserService(IBaseRepository<User> repository,
            ITokenService tokenService,
            IEmailService emailService)
        {
            _repository = repository;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public async Task<ApiResult> Login(LoginDto loginDto)
        {
            try
            {
                var validation = new LoginDtoValidator().Validate(loginDto);

                if (!validation.IsValid)
                    return Result.Error(
                        EducationHubErrors.Application_Error_InvalidRequest,
                        validation.Errors);

                var user = new User(loginDto);
                var result = await _repository.FindOneAsync(user.LoginFilterDefinition());

                if (result is null)
                    return Result.Error(EducationHubErrors.Login_Error_WrongEmailOrPassword);
                        
                var token = _tokenService.GenerateToken(result);

                return Result.Success(
                    EducationHubMessages.Login_Success,
                    responseData: new { Token = token });
            }
            catch (Exception ex)
            {
                return Result.Success(EducationHubErrors.Application_Error_General, ex.ToJson());
            }
        }

        public async Task<ApiResult> SignUp(SignUpDto signUpDto)
        {
            try
            {
                var validation = new SignUpDtoValidator().Validate(signUpDto);

                if (!validation.IsValid)
                    return Result.Error(
                        EducationHubErrors.Application_Error_InvalidRequest,
                        validation.Errors);

                var user = new User(signUpDto);
                var existsUser = await _repository.FindOneAsync(user.FindByEmailOrUsernameFilterDefinition());

                if (existsUser is not null)
                    return Result.Error(EducationHubErrors.SignUp_Error_UserAlreadyExists);

                _emailService.Send();

                //await _repository.InsertOneAsync(user);


                return Result.Success(EducationHubMessages.SignUp_Success);
            }
            catch (Exception ex)
            {
                return Result.Success(EducationHubErrors.Application_Error_General, ex.ToJson());
            }
        }
    }
}