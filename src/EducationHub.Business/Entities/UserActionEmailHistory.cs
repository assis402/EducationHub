using EducationHub.Business.Enums;
using EducationHub.Business.Helpers;
using EducationHub.Shared.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Entities
{
    public class UserActionEmailHistory : BaseEntity
    {
        public UserActionEmailHistory(string userId, EmailType type)
        {
            UserId = userId;
            Type = type;
            Token = CryptographyMD5.EncryptRandomValue();
            LastSendAt = Utils.BrazilDateTime();
        }

        public string UserId { get; private set; }

        public EmailType Type { get; private set; }

        public string Token { get; private set; }

        public bool Completed { get; private set; }

        public DateTime? LastSendAt { get; private set; }

        public void SetAsCompleted() => Completed = true;

        public void UpdateToResend()
        {
            Token = CryptographyMD5.EncryptRandomValue();
            LastSendAt = Utils.BrazilDateTime();
        }

        //public UpdateDefinition<UserActionEmailHistory> CompleteUpdateDefinition()
        //    => Builders<UserActionEmailHistory>.Update.Set(nameof(Completed).ToLower(), Completed);

        public UpdateDefinition<UserActionEmailHistory> ResendUpdateDefinition()
            => Builders<UserActionEmailHistory>.Update.Set(nameof(Token).FirstCharToLowerCase(), Token)
                                                      .Set(nameof(LastSendAt).FirstCharToLowerCase(), LastSendAt);

        public FilterDefinition<UserActionEmailHistory> FindByUserIdAndTypeFilterDefinition()
            => Builders<UserActionEmailHistory>.Filter.Where(x => x.UserId.Equals(this.UserId) || x.Type.Equals(this.Type));

        public static UpdateDefinition<UserActionEmailHistory> CompleteUpdateDefinition()
            => Builders<UserActionEmailHistory>.Update.Set(nameof(Completed).FirstCharToLowerCase(), true);

        public static FilterDefinition<UserActionEmailHistory> FindByUserIdAndTypeFilterDefinition(string userId, EmailType emailType)
            => Builders<UserActionEmailHistory>.Filter.Where(x => x.UserId.Equals(userId) && x.Type.Equals(emailType));

        public static FilterDefinition<UserActionEmailHistory> FindUncompletedFilterDefinition(string userId, EmailType emailType)
            => Builders<UserActionEmailHistory>.Filter.Where(x => x.UserId.Equals(userId) && x.Type.Equals(emailType) && x.Completed.Equals(false));
    }
}