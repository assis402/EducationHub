using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Shared.Dtos
{
    public class BaseDto
    {
        public string UserId { get; private set; }

        public void SetUserId(ClaimsPrincipal user) => UserId = user?.Claims?.FirstOrDefault(x => x.Type.Equals("Id")).Value;
    }
}
