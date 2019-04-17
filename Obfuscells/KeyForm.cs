using System;
using System.Windows.Forms;

namespace Obfuscells {
    public partial class KeyForm : Form {
        private static string passphrase;
        private static int encryptionMode;

        public KeyForm(string titlelblText, string acceptbtnText) {
            InitializeComponent();
            Encryptbtn.Text = acceptbtnText;
            TitleLbl.Text = titlelblText;
            AES192opt.Checked = true;
        }

        public string GetPassphrase() {
            return passphrase;
        }

        public int GetEncryptionMode() {
            return encryptionMode;
        }

        private void Encryptbtn_Click(object sender, EventArgs e) {
            passphrase = passphraseTextbox.Text;
            if (XORopt.Checked) encryptionMode = 0;
            if (AES192opt.Checked) encryptionMode = 1;
            if (AES256opt.Checked) encryptionMode = 2;
            Close();
            DialogResult = DialogResult.Yes;
        }

        private void Cancelbtn_Click(object sender, EventArgs e) {
        }

    }
}
