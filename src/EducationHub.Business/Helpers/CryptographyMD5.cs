using System.Security.Cryptography;
using System.Text;

namespace EducationHub.Business.Helpers
{
    public static class CryptographyMD5
    {
        public static string Encrypt(string toEncrypt)
        {
            var byteArray = MD5.HashData(Encoding.UTF8.GetBytes(toEncrypt));
            var stringBuilder = new StringBuilder();

            foreach (var @byte in byteArray)
            {
                stringBuilder.Append(@byte.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        //public static bool CompareWithUnencrypted(string unencrypted, string encrypted)
        //{
        //    using var md5Hash = MD5.Create();
        //    var stringComparer = StringComparer.OrdinalIgnoreCase;

        //    return stringComparer.Compare(Encrypt(unencrypted), encrypted).Equals(0);
        //}
    }
}