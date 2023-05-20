namespace EducationHub.Shared.Environment
{
    public static class Settings
    {
        public static readonly string Secret = System.Environment.GetEnvironmentVariable("SECRET");
        public static readonly string ConnectionString = System.Environment.GetEnvironmentVariable("CONNECTION_STRING");
        public static readonly string Database = System.Environment.GetEnvironmentVariable("DATABASE");
        public static readonly string EmailSender = System.Environment.GetEnvironmentVariable("EMAIL_SENDER");
        public static readonly string EmailSenderAppPass = System.Environment.GetEnvironmentVariable("EMAIL_SENDER_APP_PASS");
    }
}