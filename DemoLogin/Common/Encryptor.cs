using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoLogin.Common
{
    public class Encryptor
    {
        /// <summary>
        /// Chuyển đổi chuỗi thành chuỗi mã hóa
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string MD5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sHash = new StringBuilder();
            foreach(byte b in bHash)
            {
                sHash.Append(String.Format("{0:x2}", b));
            }
            return sHash.ToString();
        }
    }
}
