using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PLCCom_Full_Test_App
{
    internal class AesEncryption
    {
        private static readonly byte[] Key = Encoding.ASCII.GetBytes("a1f256d8190d4fc48895692460b98869"); // 32 byte key for AES-128
        private static readonly byte[] IV = Encoding.ASCII.GetBytes("45aa18a4565b93d5");  // 16 byte initialization vector

        internal static string EncryptString(string plainText)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {

                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            return Convert.ToBase64String(msEncrypt.ToArray());
                        }
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        internal static string DecryptString(string cipherText)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}