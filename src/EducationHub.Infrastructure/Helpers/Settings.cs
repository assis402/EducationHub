namespace EducationHub.Infrastructure.Helpers
{
    public static class Settings
    {
        public static readonly string Secret = Environment.GetEnvironmentVariable("SECRET");
    }
}
