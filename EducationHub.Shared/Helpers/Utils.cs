using System.Text;

namespace EducationHub.Shared.Helpers
{
    public static class Utils
    {
        public static byte[] ConvertToASCII(this string text)
            => Encoding.ASCII.GetBytes(text);
    }
}