﻿using System.Security.Cryptography;
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

        public static string EncryptRandomValue() => Encrypt(Guid.NewGuid().ToString());
    }
}