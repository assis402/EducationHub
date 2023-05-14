using EducationHub.Business.Entities;

namespace EducationHub.Business.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}