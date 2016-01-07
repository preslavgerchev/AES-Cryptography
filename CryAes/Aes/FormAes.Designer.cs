namespace Aes
{
    partial class FormAes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPlain = new System.Windows.Forms.TextBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lbPlain = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.tbCipher = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lbCipher = new System.Windows.Forms.Label();
            this.cbKeyLength = new System.Windows.Forms.ComboBox();
            this.lbKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPlain
            // 
            this.tbPlain.Location = new System.Drawing.Point(73, 107);
            this.tbPlain.Name = "tbPlain";
            this.tbPlain.Size = new System.Drawing.Size(386, 20);
            this.tbPlain.TabIndex = 0;
            this.tbPlain.Text = "12345689abcdefgh";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(73, 74);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(386, 20);
            this.tbKey.TabIndex = 1;
            this.tbKey.Text = "11223344556677889900aabbccddeeff";
            // 
            // lbPlain
            // 
            this.lbPlain.AutoSize = true;
            this.lbPlain.Location = new System.Drawing.Point(32, 110);
            this.lbPlain.Name = "lbPlain";
            this.lbPlain.Size = new System.Drawing.Size(29, 13);
            this.lbPlain.TabIndex = 11;
            this.lbPlain.Text = "plain";
            this.lbPlain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEncrypt.Location = new System.Drawing.Point(73, 186);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(103, 42);
            this.btnEncrypt.TabIndex = 14;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // tbCipher
            // 
            this.tbCipher.Location = new System.Drawing.Point(73, 146);
            this.tbCipher.Name = "tbCipher";
            this.tbCipher.Size = new System.Drawing.Size(386, 20);
            this.tbCipher.TabIndex = 15;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDecrypt.Location = new System.Drawing.Point(356, 186);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(103, 42);
            this.btnDecrypt.TabIndex = 17;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lbCipher
            // 
            this.lbCipher.AutoSize = true;
            this.lbCipher.Location = new System.Drawing.Point(32, 149);
            this.lbCipher.Name = "lbCipher";
            this.lbCipher.Size = new System.Drawing.Size(36, 13);
            this.lbCipher.TabIndex = 18;
            this.lbCipher.Text = "cipher";
            this.lbCipher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKeyLength
            // 
            this.cbKeyLength.FormattingEnabled = true;
            this.cbKeyLength.Items.AddRange(new object[] {
            "128 key",
            "192 key",
            "256 key"});
            this.cbKeyLength.Location = new System.Drawing.Point(73, 32);
            this.cbKeyLength.Name = "cbKeyLength";
            this.cbKeyLength.Size = new System.Drawing.Size(121, 21);
            this.cbKeyLength.TabIndex = 19;
            this.cbKeyLength.Text = "Select a key";
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(32, 77);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(24, 13);
            this.lbKey.TabIndex = 20;
            this.lbKey.Text = "key";
            this.lbKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormAes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 328);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.cbKeyLength);
            this.Controls.Add(this.lbCipher);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.tbCipher);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.lbPlain);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.tbPlain);
            this.Name = "FormAes";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPlain;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lbPlain;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox tbCipher;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lbCipher;
        private System.Windows.Forms.ComboBox cbKeyLength;
        private System.Windows.Forms.Label lbKey;
    }
}

