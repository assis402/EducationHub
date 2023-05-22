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

        public async Task<UserActionEmailHistory> Insert(string userId, EmailType emailType)
        {
            var existentEntity = await _repository.FindOneAsync(UserActionEmailHistory.FindByUserIdAndTypeFilterDefinition(userId, emailType));

            if (existentEntity is null)
            {
                var entity = new UserActionEmailHistory(userId, emailType);
                await _repository.InsertOneAsync(entity);
                return entity;
            }
            else
            {
                existentEntity.UpdateToResend();
                await _repository.UpdateAsync(existentEntity, existentEntity.ResendUpdateDefinition());
                return existentEntity;
            }
        }

        public async Task<bool> CompleteAction(string userId, EmailType emailType)
        {
            var filterDefinition = UserActionEmailHistory.FindUncompletedFilterDefinition(userId, emailType);

            var exists = await _repository.Exists(filterDefinition);

            if (!exists)
                return false;

            await _repository.UpdateAsync(filterDefinition, 
                UserActionEmailHistory.CompleteUpdateDefinition());

            return true;
        }
    }
}
