namespace EducationHub.Shared.Dtos
{
    public class SignUpDto
    {
        public string Username { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public string Role { get; init; }

        public string Token { get; set; }
    }
}