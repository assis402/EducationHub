using EducationHub.Business.Enums;
using EducationHub.Business.Models;
using EducationHub.Shared.Environment;
using EducationHub.Shared.Helpers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Builders
{
    internal class EmailBuilder
    {
        private readonly Email _instance = new ();
        private readonly string _sender = Settings.EmailSender;

        internal EmailBuilder WithFrom(string email)
        {
            _instance.From = new MailAddress(email);
            return this;
        }

        internal EmailBuilder WithSubject(string subject)
        {
            _instance.Subject = subject;
            return this;
        }

        internal EmailBuilder WithBody(string body)
        {
            _instance.Body = body;
            _instance.IsBodyHtml = true;
            return this;
        }

        internal EmailBuilder WithType(EmailType type)
        {
            _instance.Type = type;
            return this;
        }

        internal EmailBuilder WithTo(string email)
        {
            _instance.To.Add(email);
            return this;
        }

        internal EmailBuilder AccountConfirmation(string recipientEmail, string token)
        {
            var body = Utils.GetDocument(EmailType.AccountConfirmation.ToString(), "min.html");
            body = body.Replace("[URL]", "google.com.br");

            return WithFrom(_sender)
                  .WithSubject("Confirmação de Conta - EducationHub")
                  .WithType(EmailType.AccountConfirmation)
                  .WithBody(body)
                  .WithTo(recipientEmail);
        }

        internal Email Build() => _instance;
    }
}
