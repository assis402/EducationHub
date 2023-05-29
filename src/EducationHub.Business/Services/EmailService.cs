using EducationHub.Business.Builders;
using EducationHub.Business.Entities;
using EducationHub.Business.Interfaces.Services;
using EducationHub.Shared.Environment;
using System.Net;
using System.Net.Mail;

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
            var email = new EmailBuilder().AccountConfirmation(user, userActionEmailHistory.Token).Build();
            smtpClient.Send(email);
        }

        public void SendProfessorInvitation(string professorEmail, UserActionEmailHistory userActionEmailHistory)
        {
            var email = new EmailBuilder().ProfessorInvitation(professorEmail, userActionEmailHistory.Token).Build();
            smtpClient.Send(email);
        }
    }
}