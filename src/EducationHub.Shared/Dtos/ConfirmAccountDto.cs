using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Shared.Dtos
{
    public class ConfirmAccountDto
    {
        public string UserId { get; private set; }

        public string Token { get; private set; }
    }
}
