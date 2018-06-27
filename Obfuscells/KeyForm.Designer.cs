namespace Obfuscells {
    partial class KeyForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TitleLbl = new System.Windows.Forms.Label();
            this.passphraseTextbox = new System.Windows.Forms.TextBox();
            this.warningLbl = new System.Windows.Forms.Label();
            this.Encryptbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.XORopt = new System.Windows.Forms.RadioButton();
            this.AES256opt = new System.Windows.Forms.RadioButton();
            this.SelectBox = new System.Windows.Forms.GroupBox();
            this.AES192opt = new System.Windows.Forms.RadioButton();
            this.SelectBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(13, 13);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(194, 13);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Lock Cell(s) with the Passphrase below:";
            // 
            // passphraseTextbox
            // 
            this.passphraseTextbox.Location = new System.Drawing.Point(16, 30);
            this.passphraseTextbox.Name = "passphraseTextbox";
            this.passphraseTextbox.Size = new System.Drawing.Size(256, 20);
            this.passphraseTextbox.TabIndex = 1;
            // 
            // warningLbl
            // 
            this.warningLbl.AutoSize = true;
            this.warningLbl.Location = new System.Drawing.Point(13, 111);
            this.warningLbl.MaximumSize = new System.Drawing.Size(170, 0);
            this.warningLbl.Name = "warningLbl";
            this.warningLbl.Size = new System.Drawing.Size(154, 52);
            this.warningLbl.TabIndex = 2;
            this.warningLbl.Text = "[Warning]:\r\nIrreversible loss of cell data will occur if you forget your passphra" +
    "se.";
            // 
            // Encryptbtn
            // 
            this.Encryptbtn.Location = new System.Drawing.Point(197, 111);
            this.Encryptbtn.Name = "Encryptbtn";
            this.Encryptbtn.Size = new System.Drawing.Size(75, 23);
            this.Encryptbtn.TabIndex = 3;
            this.Encryptbtn.Text = "Encrypt";
            this.Encryptbtn.UseVisualStyleBackColor = true;
            this.Encryptbtn.Click += new System.EventHandler(this.Encryptbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbtn.Location = new System.Drawing.Point(197, 140);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.Cancelbtn.TabIndex = 4;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // XORopt
            // 
            this.XORopt.AutoSize = true;
            this.XORopt.Location = new System.Drawing.Point(11, 19);
            this.XORopt.Name = "XORopt";
            this.XORopt.Size = new System.Drawing.Size(48, 17);
            this.XORopt.TabIndex = 7;
            this.XORopt.TabStop = true;
            this.XORopt.Text = "XOR";
            this.XORopt.UseVisualStyleBackColor = true;
            // 
            // AES256opt
            // 
            this.AES256opt.AutoSize = true;
            this.AES256opt.Location = new System.Drawing.Point(135, 19);
            this.AES256opt.Name = "AES256opt";
            this.AES256opt.Size = new System.Drawing.Size(64, 17);
            this.AES256opt.TabIndex = 8;
            this.AES256opt.TabStop = true;
            this.AES256opt.Text = "AES256";
            this.AES256opt.UseVisualStyleBackColor = true;
            // 
            // SelectBox
            // 
            this.SelectBox.Controls.Add(this.AES192opt);
            this.SelectBox.Controls.Add(this.XORopt);
            this.SelectBox.Controls.Add(this.AES256opt);
            this.SelectBox.Location = new System.Drawing.Point(16, 56);
            this.SelectBox.Name = "SelectBox";
            this.SelectBox.Size = new System.Drawing.Size(256, 49);
            this.SelectBox.TabIndex = 10;
            this.SelectBox.TabStop = false;
            this.SelectBox.Text = "Encryption Method:";
            // 
            // AES192opt
            // 
            this.AES192opt.AutoSize = true;
            this.AES192opt.Location = new System.Drawing.Point(65, 19);
            this.AES192opt.Name = "AES192opt";
            this.AES192opt.Size = new System.Drawing.Size(64, 17);
            this.AES192opt.TabIndex = 9;
            this.AES192opt.TabStop = true;
            this.AES192opt.Text = "AES192";
            this.AES192opt.UseVisualStyleBackColor = true;
            // 
            // KeyForm
            // 
            this.AcceptButton = this.Encryptbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbtn;
            this.ClientSize = new System.Drawing.Size(284, 174);
            this.Controls.Add(this.SelectBox);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Encryptbtn);
            this.Controls.Add(this.warningLbl);
            this.Controls.Add(this.passphraseTextbox);
            this.Controls.Add(this.TitleLbl);
            this.Name = "KeyForm";
            this.Text = "Obfuscells Passphrase";
            this.TopMost = true;
            this.SelectBox.ResumeLayout(false);
            this.SelectBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.TextBox passphraseTextbox;
        private System.Windows.Forms.Label warningLbl;
        private System.Windows.Forms.Button Encryptbtn;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.RadioButton XORopt;
        private System.Windows.Forms.RadioButton AES256opt;
        private System.Windows.Forms.GroupBox SelectBox;
        private System.Windows.Forms.RadioButton AES192opt;
    }
}