namespace DepoYonetim
{
    partial class PersonelGirisForm
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
            this.label_Tc = new System.Windows.Forms.Label();
            this.label_Sifre = new System.Windows.Forms.Label();
            this.textBox_PerSifre = new System.Windows.Forms.TextBox();
            this.label_PersonelGirisSayfasi = new System.Windows.Forms.Label();
            this.maskedTextBox_PerTc = new System.Windows.Forms.MaskedTextBox();
            this.button_Giris = new System.Windows.Forms.Button();
            this.linkLabel_PerKayit = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label_Tc
            // 
            this.label_Tc.AutoSize = true;
            this.label_Tc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_Tc.Location = new System.Drawing.Point(225, 169);
            this.label_Tc.Name = "label_Tc";
            this.label_Tc.Size = new System.Drawing.Size(45, 24);
            this.label_Tc.TabIndex = 0;
            this.label_Tc.Text = "TC :";
            // 
            // label_Sifre
            // 
            this.label_Sifre.AutoSize = true;
            this.label_Sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_Sifre.Location = new System.Drawing.Point(225, 221);
            this.label_Sifre.Name = "label_Sifre";
            this.label_Sifre.Size = new System.Drawing.Size(57, 24);
            this.label_Sifre.TabIndex = 1;
            this.label_Sifre.Text = "Şifre :";
            // 
            // textBox_PerSifre
            // 
            this.textBox_PerSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBox_PerSifre.Location = new System.Drawing.Point(302, 218);
            this.textBox_PerSifre.Name = "textBox_PerSifre";
            this.textBox_PerSifre.Size = new System.Drawing.Size(126, 29);
            this.textBox_PerSifre.TabIndex = 3;
            // 
            // label_PersonelGirisSayfasi
            // 
            this.label_PersonelGirisSayfasi.AutoSize = true;
            this.label_PersonelGirisSayfasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label_PersonelGirisSayfasi.Location = new System.Drawing.Point(200, 63);
            this.label_PersonelGirisSayfasi.Name = "label_PersonelGirisSayfasi";
            this.label_PersonelGirisSayfasi.Size = new System.Drawing.Size(271, 29);
            this.label_PersonelGirisSayfasi.TabIndex = 4;
            this.label_PersonelGirisSayfasi.Text = "Personel Giris Sayfası";
            // 
            // maskedTextBox_PerTc
            // 
            this.maskedTextBox_PerTc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.maskedTextBox_PerTc.Location = new System.Drawing.Point(302, 166);
            this.maskedTextBox_PerTc.Mask = "99999999999";
            this.maskedTextBox_PerTc.Name = "maskedTextBox_PerTc";
            this.maskedTextBox_PerTc.Size = new System.Drawing.Size(126, 29);
            this.maskedTextBox_PerTc.TabIndex = 5;
            // 
            // button_Giris
            // 
            this.button_Giris.Location = new System.Drawing.Point(302, 279);
            this.button_Giris.Name = "button_Giris";
            this.button_Giris.Size = new System.Drawing.Size(126, 29);
            this.button_Giris.TabIndex = 6;
            this.button_Giris.Text = "Giris Yap";
            this.button_Giris.UseVisualStyleBackColor = true;
            this.button_Giris.Click += new System.EventHandler(this.button_Giris_Click);
            // 
            // linkLabel_PerKayit
            // 
            this.linkLabel_PerKayit.AutoSize = true;
            this.linkLabel_PerKayit.Location = new System.Drawing.Point(464, 227);
            this.linkLabel_PerKayit.Name = "linkLabel_PerKayit";
            this.linkLabel_PerKayit.Size = new System.Drawing.Size(109, 20);
            this.linkLabel_PerKayit.TabIndex = 7;
            this.linkLabel_PerKayit.TabStop = true;
            this.linkLabel_PerKayit.Text = "Personel Kayıt";
            this.linkLabel_PerKayit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_PerKayit_LinkClicked);
            // 
            // PersonelGirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(754, 339);
            this.Controls.Add(this.linkLabel_PerKayit);
            this.Controls.Add(this.button_Giris);
            this.Controls.Add(this.maskedTextBox_PerTc);
            this.Controls.Add(this.label_PersonelGirisSayfasi);
            this.Controls.Add(this.textBox_PerSifre);
            this.Controls.Add(this.label_Sifre);
            this.Controls.Add(this.label_Tc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PersonelGirisForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Tc;
        private System.Windows.Forms.Label label_Sifre;
        private System.Windows.Forms.TextBox textBox_PerSifre;
        private System.Windows.Forms.Label label_PersonelGirisSayfasi;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PerTc;
        private System.Windows.Forms.Button button_Giris;
        private System.Windows.Forms.LinkLabel linkLabel_PerKayit;
    }
}

