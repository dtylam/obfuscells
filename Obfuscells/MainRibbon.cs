using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace Obfuscells {
    public partial class MainRibbon {
        private static Range selectedRange;
        private static Random rand = new Random();
        private static int saltlength = 8;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e) {

        }
        private void Lockbtn_Click(object sender, RibbonControlEventArgs e) {
            KeyForm lockDialog = new KeyForm("Lock Cell(s) with the below passphrase:", "Encrypt");
            selectedRange = Globals.ThisAddIn.Application.Selection;
            lockDialog.StartPosition = FormStartPosition.CenterParent;
            lockDialog.ShowDialog();
            if (lockDialog.DialogResult == DialogResult.Cancel) return;
            string passphrase = lockDialog.GetPassphrase();
            int mode = lockDialog.GetMode();
            try {
                foreach (Range thisCell in selectedRange) {
                    if (thisCell.Value == null) continue;
                    string cellValue = thisCell.Formula.ToString();
                    switch (mode) {
                        case 1:
                            thisCell.Formula = AESen(cellValue, passphrase, 192);
                            break;
                        case 2:
                            thisCell.Formula = AESen(cellValue, passphrase, 256);
                            break;
                        default:
                            thisCell.Formula = Xor(cellValue, passphrase);
                            break;
                    }
                }
            }
            catch (Exception err) {
                MessageBox.Show("Error: " + err.Message);
            }
        }
        private void Unlockbtn_Click(object sender, RibbonControlEventArgs e) {
            KeyForm lockDialog = new KeyForm("Unlock Cell(s) with the below passphrase:", "Decrypt");
            selectedRange = Globals.ThisAddIn.Application.Selection;
            lockDialog.StartPosition = FormStartPosition.CenterParent;
            lockDialog.ShowDialog();
            if (lockDialog.DialogResult == DialogResult.Cancel) return;
            string passphrase = lockDialog.GetPassphrase();
            int mode = lockDialog.GetMode();
            try {
                foreach (Range thisCell in selectedRange) {
                    if (thisCell.Value == null) continue;
                    string cellValue = thisCell.Value.ToString();
                    switch (mode) {
                        case 1:
                            thisCell.Formula = AESde(cellValue, passphrase, 192);
                            break;
                        case 2:
                            thisCell.Formula = AESde(cellValue, passphrase, 256);
                            break;
                        default:
                            thisCell.Formula = Xor(cellValue, passphrase);
                            break;
                    }
                }
            }
            catch (Exception err) {
                MessageBox.Show("Error: " + err.Message);
            }
        }

        private static string Xor(string cellValue, string passphrase) {
            string resultString = "";
            int[] cipher = new int[cellValue.Length];
            int passIterator = 0;
            for (int i = 0; i < cellValue.Length; i++) {
                cipher[i] = passphrase[passIterator];
                if (cellValue[i] == cipher[i]) resultString += cellValue[i];
                else resultString += (char)(cellValue[i] ^ cipher[i]);
                passIterator++;
                if (passIterator == passphrase.Length) passIterator = 0;
            }
            return resultString;
        }
 
        public string AESen(string cellValue, string passphrase, int keySize) {
            byte[] saltBytes = new byte[saltlength];
            rand.NextBytes(saltBytes);
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(cellValue);
            byte[] passphraseBytes = Encoding.UTF8.GetBytes(passphrase);
            passphraseBytes = SHA256.Create().ComputeHash(passphraseBytes);
            byte[] encryptedBytes;
            byte[] outputBytes;

            using (MemoryStream ms = new MemoryStream()) {
                using (RijndaelManaged AES = new RijndaelManaged()) {
                    AES.KeySize = keySize;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passphraseBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                    outputBytes = new byte[saltBytes.Length + encryptedBytes.Length];
                    saltBytes.CopyTo(outputBytes, 0);
                    encryptedBytes.CopyTo(outputBytes, saltBytes.Length);
                }
            }
            return Convert.ToBase64String(outputBytes);
        }

        public string AESde(string cellValue, string passphrase, int keySize) {
            byte[] inputBytes = Convert.FromBase64String(cellValue);
            byte[] saltBytes = new byte[saltlength];
            byte[] bytesToBeDecrypted = new byte[inputBytes.Length - saltlength];
            for (int i = 0; i < inputBytes.Length; i++) {
                if (i < saltlength) saltBytes[i] = inputBytes[i];
                else bytesToBeDecrypted[i - saltlength] = inputBytes[i];
            }
            byte[] passphraseBytes = Encoding.UTF8.GetBytes(passphrase);
            passphraseBytes = SHA256.Create().ComputeHash(passphraseBytes);
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream()) {
                using (RijndaelManaged AES = new RijndaelManaged()) {
                    AES.KeySize = keySize;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passphraseBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write)) {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
