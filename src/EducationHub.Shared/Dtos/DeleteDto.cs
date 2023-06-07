using System.Security.Claims;

namespace EducationHub.Shared.Dtos
{
    public class DeleteDto : BaseDto
    {
        public DeleteDto(string id, ClaimsPrincipal user) : base(user)
        {
            Id = id;
        }

        public string Id { get; init; }
    }
}