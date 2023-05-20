﻿using EducationHub.Business.Enums;
using EducationHub.Business.Models;
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
        private readonly Email _instance = new Email();

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

        internal Email Build() =>
    }
}