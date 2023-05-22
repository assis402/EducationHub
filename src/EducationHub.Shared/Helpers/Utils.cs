﻿using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace EducationHub.Shared.Helpers
{
    public static class Utils
    {
        public static byte[] ConvertToASCII(this string text)
            => Encoding.ASCII.GetBytes(text);

        public static string ToJson(this object @object)
            => JsonConvert.SerializeObject(@object, Formatting.Indented);
        
        public static TObject ToObject<TObject>(this string json)
            => JsonConvert.DeserializeObject<TObject>(json);

        public static DateTime BrazilDateTime()
        {
            var timeUtc = DateTime.UtcNow;
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var test = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeZone);
            return test;
        }

        public static string GetDocument(string name, string extension)
        {
            var root = Directory.GetCurrentDirectory();
            var filePath = Path.GetFullPath(Path.Combine(root, $@"..\Documents\{name}.{extension}"));

            if (!File.Exists(filePath))
                return null;

            return File.ReadAllText(filePath);
        }

        public static string FirstCharToLowerCase(this string @string) 
            => char.ToLowerInvariant(@string[0]) + @string[1..];
    }
}