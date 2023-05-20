using Newtonsoft.Json;
using System.Text;

namespace EducationHub.Shared.Helpers
{
    public static class Utils
    {
        public static byte[] ConvertToASCII(this string text)
            => Encoding.ASCII.GetBytes(text);

        public static string ToJson(this object @object)
            => JsonConvert.SerializeObject(@object, Formatting.Indented);

        public static DateTime ToBrazilTime(this DateTime dateTime)
            => TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public static string GetDocument(string name, string extension)
        {
            var root = Directory.GetCurrentDirectory();
            var filePath = Path.GetFullPath(Path.Combine(root, $@"..\Documents\{name}.{extension}"));

            if (!File.Exists(filePath))
                return null;

            return File.ReadAllText(filePath);
        }
    }
}