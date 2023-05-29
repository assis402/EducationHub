using EducationHub.Business.Entities;
using EducationHub.Business.Enums;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IUserActionEmailHistoryService
    {
        public Task<UserActionEmailHistory> Insert(User user, EmailType emailType);

        public Task<UserActionEmailHistory> Insert(string email, EmailType emailType);

        public Task<bool> CompleteActionByUserIdAndToken(string userId, string token, EmailType emailType);

        public Task<bool> CompleteActionByEmailAndToken(string email, string token, string userId, EmailType emailType);
    }
}