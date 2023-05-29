using EducationHub.Business.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace EducationHub.API.CustomAttributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params UserRole[] roles) : base()
        {
            Roles = string.Join(",", roles.Select(x => x.ToString().ToLower()));
        }
    }
}