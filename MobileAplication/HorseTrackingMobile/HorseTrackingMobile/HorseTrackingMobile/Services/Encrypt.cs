using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HorseTrackingMobile.Services
{
    public class Encrypt : IEncrypt
    {
        public string EncryptText(string toEncrypt)
        {
            byte[] key = Encoding.UTF8.GetBytes("ToJestKlucz12345"); // Klucz powinien być 16, 24 lub 32 bajty
            byte[] iv = Encoding.UTF8.GetBytes("ToJestIV12345678"); // IV powinien mieć 16 bajtów

            var zaszyfrowaneDane = EncryptStringToBytes_Aes(toEncrypt, key, iv);

            return Convert.ToBase64String(zaszyfrowaneDane);
        }

        public string DecryptText(string toDecrypt)
        {
            byte[] key = Encoding.UTF8.GetBytes("ToJestKlucz12345"); // Klucz powinien być 16, 24 lub 32 bajty
            byte[] iv = Encoding.UTF8.GetBytes("ToJestIV12345678"); // IV powinien mieć 16 bajtów
            var byteToDecrypt = Convert.FromBase64String(toDecrypt);
            string odszyfrowaneDane = DecryptStringFromBytes_Aes(byteToDecrypt, key, iv);

            return odszyfrowaneDane;
        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}