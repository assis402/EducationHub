using EducationHub.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EducationHub.Shared.Environment;
using Microsoft.AspNetCore.Http;

namespace EducationHub.Business.Services
{
    public class EmailService : IEmailService
    {
        private const string SMTP_HOST = "smtp.gmail.com";

        public EmailService() { }

        public async Task Send(string recipientEmail)
        {
            var sender = Settings.EmailSender;
            var smtpClient = new SmtpClient(SMTP_HOST)
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, Settings.EmailSenderAppPass),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(sender),
                Subject = "subject",
                Body = "<h1>Hello</h1>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(recipientEmail);
            smtpClient.Send(mailMessage);
        }
    }
}
