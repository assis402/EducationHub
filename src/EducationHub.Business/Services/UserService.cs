using ApiResults;
using EducationHub.Business.Entities;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Business.Messages;
using EducationHub.Business.Validators.User;
using EducationHub.Shared.Dtos.User;
using EducationHub.Shared.Helpers;

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

                return user.Role switch
                {
                    UserRole.Student => await StudentSignUp(user),
                    UserRole.Professor => await ProfessorSignUp(user, signUpDto.Token),
                    _ => throw new NotImplementedException(),
                };
            }
            catch (Exception ex)
            {
                return Result.Success(EducationHubErrors.Application_Error_General, ex.ToJson());
            }
        }

        private async Task<ApiResult> StudentSignUp(User user)
        {
            await _repository.InsertOneAsync(user);

            var emailHistory = await _userActionEmailHistoryService.Insert(user, EmailType.AccountConfirmation);
            _emailService.SendAccountConfirmation(user, emailHistory);

            return Result.Success(EducationHubMessages.SignUp_Success);
        }

        private async Task<ApiResult> ProfessorSignUp(User user, string actionToken)
        {
            if (string.IsNullOrEmpty(actionToken))
                return Result.Error(EducationHubErrors.SignUp_Error_TokenIsNull);

            var completeActionResult = await _userActionEmailHistoryService.CompleteActionByEmailAndToken(user.Email, actionToken, user.Id.ToString(), EmailType.ProfessorInvitation);

            if (!completeActionResult)
                return Result.Error(EducationHubErrors.Action_Error_NotFound);

            await _repository.InsertOneAsync(user);

            return Result.Success(EducationHubMessages.SignUp_Success);
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

            var completeActionResult = await _userActionEmailHistoryService.CompleteActionByUserIdAndToken(confirmAccountDto.UserId, confirmAccountDto.Token, EmailType.AccountConfirmation);

            if (!completeActionResult)
                return Result.Error(EducationHubErrors.Action_Error_NotFound);

            await _repository.UpdateAsync(confirmAccountDto.UserId, User.ConfirmAccountUpdateDefinition());

            return Result.Success(EducationHubMessages.ConfirmAccount_Success);
        }

        public async Task<ApiResult> InviteProfessor(InviteProfessorDto inviteProfessorDto)
        {
            var validation = new InviteDtoValidator().Validate(inviteProfessorDto);

            if (!validation.IsValid)
                return Result.Error(
                    EducationHubErrors.Application_Error_InvalidRequest,
                    validation.Errors);

            var emailHistory = await _userActionEmailHistoryService.Insert(inviteProfessorDto.Email, EmailType.AccountConfirmation);
            _emailService.SendProfessorInvitation(inviteProfessorDto.Email, emailHistory);

            return Result.Success(EducationHubMessages.ProfessorInvitation_Success);
        }
    }
}