using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

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
    }
}