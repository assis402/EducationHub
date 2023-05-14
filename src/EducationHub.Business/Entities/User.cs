using EducationHub.API.Dtos;
using EducationHub.Business.Helpers;
using MongoDB.Driver;

namespace EducationHub.Business.Entities
{
    public class User : BaseEntity
    {    
        public User(LoginDto loginDto)
        {
            Email = loginDto.Email;
            Password = CryptographyMD5.Encrypt(loginDto.Password);
            Role = "student";
        }

        public User(SignUpDto signUpDto)
        {
            Username = signUpDto.Username;
            Email = signUpDto.Email;
            Password = CryptographyMD5.Encrypt(signUpDto.Password);
            Role = "student";
        }

        public string Username { get; private set; }

        public string Email { get; set; }

        public string Password { get; private set; }

        public string Role { get; private set; }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public UpdateDefinition<User> ChangePasswordUpdateDefinition()
            => Builders<User>.Update.Set(nameof(Password).ToLower(), Password);

        public FilterDefinition<User> LoginFilterDefinition()
            => Builders<User>.Filter.Where(x => x.Email.Equals(this.Email) && x.Password.Equals(this.Password));
    }
}