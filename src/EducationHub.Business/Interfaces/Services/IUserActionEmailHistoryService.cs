using EducationHub.Business.Entities;
using EducationHub.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IUserActionEmailHistoryService
    {
        public Task<UserActionEmailHistory> Insert(string userId, EmailType emailType);

        public Task<bool> CompleteAction(string userId, EmailType emailType);
    }
}
