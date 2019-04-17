using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Obfuscells
{
    public static class CryptoService
    {
        private static readonly Random Rand = new Random();
        private const int Saltlength = 8;

        public static void Encrypt(Range selectedRange, int encryptionMode, string passphrase)
        {
            foreach (Range thisCell in selectedRange)
            {
                if (thisCell.Value == null) continue;
                string cellValue = thisCell.Formula.ToString();
                switch (encryptionMode)
                {
                    case 1:
                        thisCell.Formula = AESencrypt(cellValue, passphrase, 192);
                        break;
                    case 2:
                        thisCell.Formula = AESencrypt(cellValue, passphrase, 256);
                        break;
                    default:
                        thisCell.Formula = Xor(cellValue, passphrase);
                        break;
                }
            }
        }

        public static void Decrypt(Range selectedRange, int encryptionMode, string passphrase)
        {
            foreach (Range thisCell in selectedRange)
            {
                if (thisCell.Value == null) continue;
                string cellValue = thisCell.Value.ToString();
                switch (encryptionMode)
                {
                    case 1:
                        thisCell.Formula = AESdecrypt(cellValue, passphrase, 192);
                        break;
                    case 2:
                        thisCell.Formula = AESdecrypt(cellValue, passphrase, 256);
                        break;
                    default:
                        thisCell.Formula = Xor(cellValue, passphrase);
                        break;
                }
            }

        }

        public static string AESencrypt(string cellValue, string passphrase, int keySize)
        {
            byte[] saltBytes = new byte[Saltlength];
            Rand.NextBytes(saltBytes);
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(cellValue);
            byte[] passphraseBytes = Encoding.UTF8.GetBytes(passphrase);
            passphraseBytes = SHA256.Create().ComputeHash(passphraseBytes);
            byte[] outputBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = keySize;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passphraseBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    var encryptedBytes = ms.ToArray();
                    outputBytes = new byte[saltBytes.Length + encryptedBytes.Length];
                    saltBytes.CopyTo(outputBytes, 0);
                    encryptedBytes.CopyTo(outputBytes, saltBytes.Length);
                }
            }
            return Convert.ToBase64String(outputBytes);
        }

        public static string AESdecrypt(string cellValue, string passphrase, int keySize)
        {
            byte[] inputBytes = Convert.FromBase64String(cellValue);
            byte[] saltBytes = new byte[Saltlength];
            byte[] bytesToBeDecrypted = new byte[inputBytes.Length - Saltlength];
            for (int i = 0; i < inputBytes.Length; i++)
            {
                if (i < Saltlength) saltBytes[i] = inputBytes[i];
                else bytesToBeDecrypted[i - Saltlength] = inputBytes[i];
            }
            byte[] passphraseBytes = Encoding.UTF8.GetBytes(passphrase);
            passphraseBytes = SHA256.Create().ComputeHash(passphraseBytes);
            byte[] decryptedBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = keySize;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passphraseBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        public static string Xor(string cellValue, string passphrase)
        {
            string resultString = "";
            int[] cipher = new int[cellValue.Length];
            int passIterator = 0;
            for (int i = 0; i < cellValue.Length; i++)
            {
                cipher[i] = passphrase[passIterator];
                if (cellValue[i] == cipher[i]) resultString += cellValue[i];
                else resultString += (char)(cellValue[i] ^ cipher[i]);
                passIterator++;
                if (passIterator == passphrase.Length) passIterator = 0;
            }
            return resultString;
        }
    }
}