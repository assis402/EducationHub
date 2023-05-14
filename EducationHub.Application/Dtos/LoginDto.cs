using EducationHub.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Application.Dtos
{
    public class LoginDto
    {
        public string Email { get; init; }

        private string password { get; set; }

        public string Password
        {
            get { return password; }
            init { password = CryptographyMD5.Encrypt(value); }
        }
    }
}
