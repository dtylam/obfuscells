using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obfuscells {
    public partial class KeyForm : Form {
        private static string passphrase;
        private static int mode = 0;
        public KeyForm(string titlelblText, string acceptbtnText) {
            InitializeComponent();
            this.Encryptbtn.Text = acceptbtnText;
            this.TitleLbl.Text = titlelblText;
            AES192opt.Checked = true;
        }

        public string GetPassphrase() {
            return passphrase;
        }

        public int GetMode() {
            return mode;
        }

        private void Encryptbtn_Click(object sender, EventArgs e) {
            passphrase = passphraseTextbox.Text;
            if (XORopt.Checked) mode = 0;
            if (AES192opt.Checked) mode = 1;
            if (AES256opt.Checked) mode = 2;
            this.Close();
            DialogResult = DialogResult.Yes;
        }

        private void Cancelbtn_Click(object sender, EventArgs e) {
        }

    }
}
