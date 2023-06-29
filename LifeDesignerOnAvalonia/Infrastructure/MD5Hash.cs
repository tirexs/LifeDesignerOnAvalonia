using System;
using System.Text;
using System.Security.Cryptography;

namespace LifeDesignerOnAvalonia.Infrastructure
{
    public class MD5Hash
    {
        public static string hashPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] b = Encoding.ASCII.GetBytes(password); 
            byte[] hash = md5.ComputeHash(b);
            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
                sb.Append(a.ToString("X2"));
            return Convert.ToString(sb);

        }
    }
}
