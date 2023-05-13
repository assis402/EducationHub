using EducationHub.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
