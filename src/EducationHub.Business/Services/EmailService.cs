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
using System.Reflection;
using EducationHub.Business.Builders;
using EducationHub.Business.Entities;
using EducationHub.Business.Models;
using EducationHub.Business.Enums;

namespace EducationHub.Business.Services
{
    public class EmailService : IEmailService
    {
        private const string SMTP_HOST = "smtp.gmail.com";
        private readonly SmtpClient smtpClient;

        public EmailService() 
        {
            smtpClient = new SmtpClient(SMTP_HOST)
            {
                Port = 587,
                Credentials = new NetworkCredential(Settings.EmailSender, Settings.EmailSenderAppPass),
                EnableSsl = true,
            };
        }

        public void SendAccountConfirmation(User user, UserActionEmailHistory userActionEmailHistory)
        {
            var email = new EmailBuilder().AccountConfirmation(user.Username, user.Email, userActionEmailHistory.Token).Build();
            smtpClient.Send(email);
        }
    }
}
