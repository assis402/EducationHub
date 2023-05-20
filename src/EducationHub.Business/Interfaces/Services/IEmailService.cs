using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IEmailService
    {
        public Task Send(string recipientEmail);
    }
}
