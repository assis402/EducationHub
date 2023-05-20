using EducationHub.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Models
{
    public class Email : MailMessage
    {
        public EmailType Type { get; set; }
    }
}
