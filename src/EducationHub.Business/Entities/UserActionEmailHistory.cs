using EducationHub.Business.Enums;
using EducationHub.Business.Helpers;
using EducationHub.Shared.Helpers;
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
            SentAt = DateTime.Now.ToBrazilTime();
            LastRetryAt = null;
        }

        public string UserId { get; private set; }

        public EmailType Type { get; private set; }

        public string Token { get; private set; }

        public DateTime SentAt { get; private set; }

        public DateTime? LastRetryAt { get; private set; }
    }
}