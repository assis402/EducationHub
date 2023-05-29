using EducationHub.Business.Enums;
using System.Net.Mail;

namespace EducationHub.Business.Models
{
    public class Email : MailMessage
    {
        public EmailType Type { get; set; }
    }
}