using EducationHub.API.Dtos;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;

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

        public async Task SignUp(SignUpDto signUpDto)
        {
            var user = new User(signUpDto);
            await _repository.InsertOneAsync(user);
        }
    }
}