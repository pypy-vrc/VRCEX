using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VRCEX
{
    public static class DESEncryption
    {
        private static readonly byte[] m_DESKey = new byte[] { 0x69, 0x00, 0x18, 0x00, 0x58, 0x00, 0x82, 0x00 };

        public static string Encrypt(string plainText, bool randomIV = true)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    var IV = new byte[8];
                    if (randomIV)
                    {
                        new RNGCryptoServiceProvider().GetBytes(IV);
                    }
                    stream.Write(IV, 0, IV.Length);
                    using (var cryptoStream = new CryptoStream(stream, new DESCryptoServiceProvider().CreateEncryptor(m_DESKey, IV), CryptoStreamMode.Write))
                    {
                        var bytes = Encoding.UTF8.GetBytes(plainText);
                        cryptoStream.Write(bytes, 0, bytes.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(stream.ToArray());
                    }
                }
            }
            catch
            {
            }
            return string.Empty;
        }

        public static bool Decrypt(string cipherText, out string plainText)
        {
            try
            {
                using (var stream = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    var IV = new byte[8];
                    stream.Read(IV, 0, 8);
                    using (var cryptoStream = new CryptoStream(stream, new DESCryptoServiceProvider().CreateDecryptor(m_DESKey, IV), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cryptoStream, Encoding.UTF8))
                        {
                            plainText = reader.ReadToEnd();
                            return true;
                        }
                    }
                }
            }
            catch
            {
            }
            plainText = string.Empty;
            return false;
        }
    }
}