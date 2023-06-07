using EducationHub.Business.Enums;
using EducationHub.Business.Helpers;
using EducationHub.Shared.Dtos.User;
using EducationHub.Shared.Helpers;
using MongoDB.Driver;

namespace EducationHub.Business.Entities
{
    public class User : BaseEntity
    {
        public User(LoginDto loginDto)
        {
            Email = loginDto.Email;
            Password = CryptographyMD5.Encrypt(loginDto.Password);
        }

        public User(SignUpDto signUpDto)
        {
            Username = signUpDto.Username;
            Email = signUpDto.Email;
            Password = CryptographyMD5.Encrypt(signUpDto.Password);
            Role = Enum.Parse<UserRole>(signUpDto.Role, true);
            Status = UserStatus.UnconfirmedAccount;
        }

        public string Username { get; private set; }

        public string Email { get; set; }

        public string Password { get; private set; }

        public UserRole Role { get; private set; }

        public UserStatus Status { get; private set; }

        public void ChangePassword(string newPassword) => Password = newPassword;

        public UpdateDefinition<User> ChangePasswordUpdateDefinition()
            => Builders<User>.Update.Set(nameof(Password).FirstCharToLowerCase(), Password);

        public static UpdateDefinition<User> ConfirmAccountUpdateDefinition()
            => Builders<User>.Update.Set(nameof(Status).FirstCharToLowerCase(), UserStatus.Active);

        public static FilterDefinition<User> LoginFilterDefinition(LoginDto loginDto)
            => Builders<User>.Filter.Where(x =>
                x.Email.Equals(loginDto.Email) &&
                x.Password.Equals(CryptographyMD5.Encrypt(loginDto.Password)));

        public FilterDefinition<User> FindByEmailOrUsernameFilterDefinition()
            => Builders<User>.Filter.Where(x => x.Email.Equals(this.Email) || x.Username.Equals(this.Username));
    }
}