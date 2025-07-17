using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PLCCom_Full_Test_App
{
    /// <summary>
    /// Provides methods for symmetric AES encryption and decryption of strings.
    /// </summary>
    internal class AesEncryption
    {
        // 32-byte key for AES (AES-256 actually, despite the comment in original code)
        private static readonly byte[] Key = Encoding.ASCII.GetBytes("a1f256d8190d4fc48895692460b98869");
        // 16-byte initialization vector (IV)
        private static readonly byte[] IV = Encoding.ASCII.GetBytes("45aa18a4565b93d5");

        /// <summary>
        /// Encrypts the given plain text string using AES encryption and returns a Base64-encoded string.
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <returns>Base64-encoded encrypted string, or an empty string if encryption fails.</returns>
        internal static string EncryptString(string plainText)
        {
            try
            {
                // Create a new AES object for encryption
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    // Create an encryptor to perform the stream transform
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Use a memory stream to hold the encrypted data
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        // Create a CryptoStream using the encryptor
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            // Use a StreamWriter to write the plain text to the CryptoStream
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            // Convert encrypted bytes in memory to a Base64 string
                            return Convert.ToBase64String(msEncrypt.ToArray());
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Return empty string if encryption fails
                return string.Empty;
            }
        }

        /// <summary>
        /// Decrypts a Base64-encoded string encrypted with AES and returns the plain text.
        /// </summary>
        /// <param name="cipherText">The encrypted string (Base64 format) to decrypt.</param>
        /// <returns>The decrypted plain text, or an empty string if decryption fails.</returns>
        internal static string DecryptString(string cipherText)
        {
            try
            {
                // Create a new AES object for decryption
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    // Create a decryptor to perform the stream transform
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Convert the Base64 string to bytes and read into a memory stream
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        // Create a CryptoStream for decryption
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            // Use a StreamReader to get the decrypted plain text
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
                // Return empty string if decryption fails
                return string.Empty;
            }
        }
    }
}
