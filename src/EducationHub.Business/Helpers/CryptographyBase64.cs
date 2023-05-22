using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationHub.Business.Helpers
{
    public static class CryptographyBase64
    {
        public static string Encrypt(string toEncrypt)
        {
            var bytes = Encoding.UTF8.GetBytes(toEncrypt);
            return Convert.ToBase64String(bytes);
        }

        public static string Decrypt(string toDecrypt)
        {
            var bytes = Convert.FromBase64String(toDecrypt);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
