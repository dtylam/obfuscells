using System;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace Obfuscells {
    public partial class MainRibbon {
        
        #region UI strings //TODO: separate into resx
        private const string LockLabel = "Lock Cell(s) with the below passphrase:";
        private const string EncryptBtnText = "Encrypt";
        private const string UnlockLabel = "Unlock Cell(s) with the below passphrase:";
        private const string DecryptBtnText = "Decrypt";
        #endregion

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e) {

        }

        private void Lockbtn_Click(object sender, RibbonControlEventArgs e) {
            var selectedRange = Globals.ThisAddIn.Application.Selection;
            var lockDialog = new KeyForm(LockLabel, EncryptBtnText){
                StartPosition = FormStartPosition.CenterParent
            };
            lockDialog.ShowDialog();
            if (lockDialog.DialogResult == DialogResult.Cancel) return;

            try {
                CryptoService.Encrypt(selectedRange, 
                    lockDialog.GetEncryptionMode(), 
                    lockDialog.GetPassphrase());
            }
            catch (Exception err) {
                MessageBox.Show("Error: " + err.Message);
            }
        }

        private void Unlockbtn_Click(object sender, RibbonControlEventArgs e) {
            var selectedRange = Globals.ThisAddIn.Application.Selection;
            var lockDialog = new KeyForm(UnlockLabel, DecryptBtnText){
                StartPosition = FormStartPosition.CenterParent
            };
            lockDialog.ShowDialog();
            if (lockDialog.DialogResult == DialogResult.Cancel) return;

            try {
                CryptoService.Decrypt(selectedRange, 
                    lockDialog.GetEncryptionMode(), 
                    lockDialog.GetPassphrase());
            }
            catch (Exception err) {
                MessageBox.Show("Error: " + err.Message);
            }
        }
    }
}
