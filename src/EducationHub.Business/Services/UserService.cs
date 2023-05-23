using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Business.Validators.User;
using EducationHub.Shared.Dtos;
using EducationHub.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace EducationHub.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IUserActionEmailHistoryService _userActionEmailHistoryService;

        public UserService(IBaseRepository<User> repository,
            ITokenService tokenService,
            IEmailService emailService,
            IUserActionEmailHistoryService userActionEmailHistoryService)
        {
            _repository = repository;
            _tokenService = tokenService;
            _emailService = emailService;
            _userActionEmailHistoryService = userActionEmailHistoryService;
        }

        public async Task<ApiResult> Login(LoginDto loginDto)
        {
            try
            {
                var loginValidation = new LoginDtoValidator().Validate(loginDto);

                if (!loginValidation.IsValid)
                    return Result.Error(
                        EducationHubErrors.Application_Error_InvalidRequest,
                        loginValidation.Errors);

                var user = await _repository.FindOneAsync(User.LoginFilterDefinition(loginDto));

                if (user is null)
                    return Result.Error(EducationHubErrors.Login_Error_WrongEmailOrPassword);

                var userValidation = new UserValidator().Validate(user);

                if (!userValidation.IsValid)
                    return Result.Error(
                        EducationHubErrors.User_Validation_Fail,
                        userValidation.Errors);

                var token = _tokenService.GenerateToken(user);

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
                var existentUser = await _repository.FindOneAsync(user.FindByEmailOrUsernameFilterDefinition());

                if (existentUser is not null)
                    return Result.Error(EducationHubErrors.SignUp_Error_UserAlreadyExists);

                await _repository.InsertOneAsync(user);

                var emailHistory = await _userActionEmailHistoryService.Insert(user.Id.ToString(), EmailType.AccountConfirmation);
                _emailService.SendAccountConfirmation(user, emailHistory);

                return Result.Success(EducationHubMessages.SignUp_Success);
            }
            catch (Exception ex)
            {
                return Result.Success(EducationHubErrors.Application_Error_General, ex.ToJson());
            }
        }

        public async Task<ApiResult> ConfirmAccount(string encriptedData)
        {
            if (string.IsNullOrEmpty(encriptedData))
                return Result.Error(EducationHubErrors.Application_Error_InvalidRequest);

            var decritpedData = CryptographyBase64.Decrypt(encriptedData);
            var confirmAccountDto = decritpedData.ToObject<ConfirmAccountDto>();

            var validation = new ConfirmAccountDtoValidator().Validate(confirmAccountDto);

            if (!validation.IsValid) 
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var completeActionResult = await _userActionEmailHistoryService.CompleteAction(confirmAccountDto.UserId, EmailType.AccountConfirmation);

            if (!completeActionResult)
                return Result.Error(EducationHubErrors.ConfirmAccount_Error_NotFound);

            await _repository.UpdateAsync(confirmAccountDto.UserId, User.ConfirmAccountUpdateDefinition());

            return Result.Success(EducationHubMessages.ConfirmAccount_Success);
        }
    }
}