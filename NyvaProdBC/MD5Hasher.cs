using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace NyvaProdBC
{
    public static class MD5Hasher
    {
        const string HASH = "X2";
        public static string Encrypt(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);

            var MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = MD5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(HASH));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(bytes, 0, bytes.Length);

            return Convert.ToBase64String(result);
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=EEItNLDw0-A
        /// </summary>
        /// <param name="output"></param>
        /// <returns>MD5 decryption (possibly)</returns>
        public static string Decrypt(string output) 
        {
            byte[] bytes = Convert.FromBase64String(output);

            var MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = MD5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(HASH));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(bytes, 0, bytes.Length);

            return System.Text.UTF8Encoding.UTF8.GetString(result);
        }
        public static string EncryptOneWay(string input)
        {
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(input);
                b = MD5.ComputeHash(b);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (byte x in b)

                    sb.Append(x.ToString(HASH));

                return sb.ToString();
            }
        }
        //public static string Decode(string hash)
        //{
        //    try
        //    {
        //        var encoder = new System.Text.UTF8Encoding();
        //        System.Text.Decoder utf8Decode = encoder.GetDecoder();
        //        byte[] todecodeByte = Convert.FromBase64String(input);
        //        int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
        //        char[] decodedChar = new char[charCount];
        //        utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
        //        string result = new String(decodedChar);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in base64Decode" + ex.Message);
        //    }
        //}
    }
}