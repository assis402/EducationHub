using EducationHub.Business.Entities;
using EducationHub.Business.Enums;
using EducationHub.Business.Interfaces.Repositories;
using EducationHub.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var entity = new UserActionEmailHistory(userId, emailType);
            //TODO: checar se existe outro com o mesmo tipo e apenas atualizar;
            await _repository.InsertOneAsync(entity);
            return entity;
        }

        public async Task CompleteAction(string userId, EmailType emailType)
        {

        }

        public async Task CompleteAction(UserActionEmailHistory entity)
        {
            await _repository.UpdateAsync(entity.FindByUserIdAndTypeFilterDefinition(), entity.CompleteActionUpdateDefinition());
        }
    }
}
