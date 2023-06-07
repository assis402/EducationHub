using System.Security.Claims;

namespace EducationHub.Shared.Dtos
{
    public abstract class BaseDto
    {
        protected BaseDto()
        { }

        protected BaseDto(ClaimsPrincipal user) => SetUserId(user);

        public string UserId { get; private set; }

        public void SetUserId(ClaimsPrincipal user) => UserId = user?.Claims?.FirstOrDefault(x => x.Type.Equals("Id")).Value;
    }
}