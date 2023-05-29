namespace EducationHub.Shared.Dtos
{
    public class ConfirmAccountDto
    {
        public ConfirmAccountDto(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }

        public string UserId { get; private set; }

        public string Token { get; private set; }
    }
}