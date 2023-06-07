using EducationHub.Business.Entities;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;

namespace EducationHub.Business.Services
{
    public class UserActionEmailHistoryService : IUserActionEmailHistoryService
    {
        private readonly IBaseRepository<UserActionEmailHistory> _repository;

        public UserActionEmailHistoryService(IBaseRepository<UserActionEmailHistory> repository)
        {
            _repository = repository;
        }

        public async Task<UserActionEmailHistory> Insert(User user, EmailType emailType)
        {
            var existentEntity = await _repository.FindOneAsync(UserActionEmailHistory.FindByUserIdAndTypeFilterDefinition(user.Id.ToString(), emailType));

            if (existentEntity is null)
            {
                var entity = new UserActionEmailHistory(user, emailType);
                await _repository.InsertOneAsync(entity);
                return entity;
            }
            else
            {
                existentEntity.UpdateToResend();
                await _repository.UpdateOneAsync(existentEntity, existentEntity.ResendUpdateDefinition());
                return existentEntity;
            }
        }

        public async Task<UserActionEmailHistory> Insert(string email, EmailType emailType)
        {
            var existentEntity = await _repository.FindOneAsync(UserActionEmailHistory.FindByEmailAndTypeFilterDefinition(email, emailType));

            if (existentEntity is null)
            {
                var entity = new UserActionEmailHistory(email, emailType);
                await _repository.InsertOneAsync(entity);
                return entity;
            }
            else
            {
                existentEntity.UpdateToResend();
                await _repository.UpdateOneAsync(existentEntity, existentEntity.ResendUpdateDefinition());
                return existentEntity;
            }
        }

        public async Task<bool> CompleteActionByUserIdAndToken(string userId, string token, EmailType emailType)
        {
            var filterDefinition = UserActionEmailHistory.FindUncompletedByUserIdFilterDefinition(userId, token, emailType);

            var exists = await _repository.Exists(filterDefinition);

            if (!exists)
                return false;

            await _repository.UpdateOneAsync(filterDefinition,
                UserActionEmailHistory.CompleteUpdateDefinition());

            return true;
        }

        public async Task<bool> CompleteActionByEmailAndToken(string email, string token, string userId, EmailType emailType)
        {
            var filterDefinition = UserActionEmailHistory.FindUncompletedByEmailFilterDefinition(email, token, emailType);

            var exists = await _repository.Exists(filterDefinition);

            if (!exists)
                return false;

            await _repository.UpdateOneAsync(filterDefinition,
                UserActionEmailHistory.CompleteUpdateDefinition(userId));

            return true;
        }
    }
}