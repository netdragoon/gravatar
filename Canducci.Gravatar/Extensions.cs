using System;
using System.Security.Cryptography;
using System.Text;
namespace Canducci.Gravatar
{
    internal static class Extensions
    {
        public static string ToHash(this string str)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();            
        }
        public static string ToLower(this Enum _enum)
        {
            return _enum.
                ToString()
                .ToLower();
        }
    }
}
