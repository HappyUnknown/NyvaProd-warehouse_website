using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace NyvaProdBC
{
    public static class MD5Hasher
    {
        public static string Encrypt(string input)
        {
            string hash = "X2";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);

            var MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = MD5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(hash));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(bytes, 0, bytes.Length);

            return Convert.ToBase64String(result);
        }
        public static string Decrypt(string output) 
        {
            string hash = "X2";
            byte[] bytes = Convert.FromBase64String(output);

            var MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = MD5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(hash));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(bytes, 0, bytes.Length);

            return System.Text.UTF8Encoding.UTF8.GetString(result);
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