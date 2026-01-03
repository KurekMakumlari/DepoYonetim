namespace DepoYonetim.Forms
{
    partial class Islem
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_UrunSil = new System.Windows.Forms.Button();
            this.button_UrunGuncelle = new System.Windows.Forms.Button();
            this.button_UrunKayit = new System.Windows.Forms.Button();
            this.label_UrunAdi = new System.Windows.Forms.Label();
            this.textBox_UrunAdi = new System.Windows.Forms.TextBox();
            this.label_UrunKod = new System.Windows.Forms.Label();
            this.textBox_UrunKod = new System.Windows.Forms.TextBox();
            this.dataGridView_UrunList = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_KaliciSil = new System.Windows.Forms.Button();
            this.button_PerDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_Status = new System.Windows.Forms.RadioButton();
            this.label_KullaniciAd = new System.Windows.Forms.Label();
            this.textBox_KullaniciAd = new System.Windows.Forms.TextBox();
            this.button_PerUpdate = new System.Windows.Forms.Button();
            this.label_Role = new System.Windows.Forms.Label();
            this.label_Sifre = new System.Windows.Forms.Label();
            this.label_AdSoyad = new System.Windows.Forms.Label();
            this.comboBox_RolSecim = new System.Windows.Forms.ComboBox();
            this.dataGridViewKullanıcıList = new System.Windows.Forms.DataGridView();
            this.textBox_Sifre = new System.Windows.Forms.TextBox();
            this.button_PerKayit = new System.Windows.Forms.Button();
            this.textBox_AdSoyad = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button_LotSil = new System.Windows.Forms.Button();
            this.button_LotGuncelle = new System.Windows.Forms.Button();
            this.button_LotKayit = new System.Windows.Forms.Button();
            this.comboBox_UrunLot = new System.Windows.Forms.ComboBox();
            this.textBox_LotNo = new System.Windows.Forms.TextBox();
            this.label_LotNo = new System.Windows.Forms.Label();
            this.label_UrunID = new System.Windows.Forms.Label();
            this.dataGridView_LotList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UrunList)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanıcıList)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LotList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 518);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_UrunSil);
            this.tabPage2.Controls.Add(this.button_UrunGuncelle);
            this.tabPage2.Controls.Add(this.button_UrunKayit);
            this.tabPage2.Controls.Add(this.label_UrunAdi);
            this.tabPage2.Controls.Add(this.textBox_UrunAdi);
            this.tabPage2.Controls.Add(this.label_UrunKod);
            this.tabPage2.Controls.Add(this.textBox_UrunKod);
            this.tabPage2.Controls.Add(this.dataGridView_UrunList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1023, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Urun İşlem";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_UrunSil
            // 
            this.button_UrunSil.Location = new System.Drawing.Point(347, 186);
            this.button_UrunSil.Name = "button_UrunSil";
            this.button_UrunSil.Size = new System.Drawing.Size(75, 23);
            this.button_UrunSil.TabIndex = 21;
            this.button_UrunSil.Text = "Kalıcı Sil";
            this.button_UrunSil.UseVisualStyleBackColor = true;
            this.button_UrunSil.Click += new System.EventHandler(this.button_UrunSil_Click);
            // 
            // button_UrunGuncelle
            // 
            this.button_UrunGuncelle.Location = new System.Drawing.Point(236, 186);
            this.button_UrunGuncelle.Name = "button_UrunGuncelle";
            this.button_UrunGuncelle.Size = new System.Drawing.Size(75, 23);
            this.button_UrunGuncelle.TabIndex = 20;
            this.button_UrunGuncelle.Text = "Güncelle";
            this.button_UrunGuncelle.UseVisualStyleBackColor = true;
            this.button_UrunGuncelle.Click += new System.EventHandler(this.button_UrunGuncelle_Click);
            // 
            // button_UrunKayit
            // 
            this.button_UrunKayit.Location = new System.Drawing.Point(139, 186);
            this.button_UrunKayit.Name = "button_UrunKayit";
            this.button_UrunKayit.Size = new System.Drawing.Size(75, 23);
            this.button_UrunKayit.TabIndex = 19;
            this.button_UrunKayit.Text = "Kayıt Yap";
            this.button_UrunKayit.UseVisualStyleBackColor = true;
            this.button_UrunKayit.Click += new System.EventHandler(this.button_UrunKayit_Click);
            // 
            // label_UrunAdi
            // 
            this.label_UrunAdi.AutoSize = true;
            this.label_UrunAdi.Location = new System.Drawing.Point(76, 99);
            this.label_UrunAdi.Name = "label_UrunAdi";
            this.label_UrunAdi.Size = new System.Drawing.Size(48, 13);
            this.label_UrunAdi.TabIndex = 4;
            this.label_UrunAdi.Text = "Urun Adı";
            // 
            // textBox_UrunAdi
            // 
            this.textBox_UrunAdi.Location = new System.Drawing.Point(139, 96);
            this.textBox_UrunAdi.Name = "textBox_UrunAdi";
            this.textBox_UrunAdi.Size = new System.Drawing.Size(100, 20);
            this.textBox_UrunAdi.TabIndex = 3;
            // 
            // label_UrunKod
            // 
            this.label_UrunKod.AutoSize = true;
            this.label_UrunKod.Location = new System.Drawing.Point(76, 52);
            this.label_UrunKod.Name = "label_UrunKod";
            this.label_UrunKod.Size = new System.Drawing.Size(52, 13);
            this.label_UrunKod.TabIndex = 2;
            this.label_UrunKod.Text = "Urun Kod";
            // 
            // textBox_UrunKod
            // 
            this.textBox_UrunKod.Location = new System.Drawing.Point(139, 49);
            this.textBox_UrunKod.Name = "textBox_UrunKod";
            this.textBox_UrunKod.Size = new System.Drawing.Size(100, 20);
            this.textBox_UrunKod.TabIndex = 1;
            // 
            // dataGridView_UrunList
            // 
            this.dataGridView_UrunList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_UrunList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_UrunList.Location = new System.Drawing.Point(3, 289);
            this.dataGridView_UrunList.Name = "dataGridView_UrunList";
            this.dataGridView_UrunList.Size = new System.Drawing.Size(1017, 200);
            this.dataGridView_UrunList.TabIndex = 0;
            this.dataGridView_UrunList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UrunDataGridView_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_KaliciSil);
            this.tabPage1.Controls.Add(this.button_PerDelete);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.radioButton_Status);
            this.tabPage1.Controls.Add(this.label_KullaniciAd);
            this.tabPage1.Controls.Add(this.textBox_KullaniciAd);
            this.tabPage1.Controls.Add(this.button_PerUpdate);
            this.tabPage1.Controls.Add(this.label_Role);
            this.tabPage1.Controls.Add(this.label_Sifre);
            this.tabPage1.Controls.Add(this.label_AdSoyad);
            this.tabPage1.Controls.Add(this.comboBox_RolSecim);
            this.tabPage1.Controls.Add(this.dataGridViewKullanıcıList);
            this.tabPage1.Controls.Add(this.textBox_Sifre);
            this.tabPage1.Controls.Add(this.button_PerKayit);
            this.tabPage1.Controls.Add(this.textBox_AdSoyad);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1023, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personel İşlem";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_KaliciSil
            // 
            this.button_KaliciSil.Location = new System.Drawing.Point(519, 244);
            this.button_KaliciSil.Name = "button_KaliciSil";
            this.button_KaliciSil.Size = new System.Drawing.Size(75, 23);
            this.button_KaliciSil.TabIndex = 19;
            this.button_KaliciSil.Text = "Kalıcı Sil";
            this.button_KaliciSil.UseVisualStyleBackColor = true;
            this.button_KaliciSil.Click += new System.EventHandler(this.button_KaliciSil_Click);
            // 
            // button_PerDelete
            // 
            this.button_PerDelete.Location = new System.Drawing.Point(403, 244);
            this.button_PerDelete.Name = "button_PerDelete";
            this.button_PerDelete.Size = new System.Drawing.Size(75, 23);
            this.button_PerDelete.TabIndex = 18;
            this.button_PerDelete.Text = "Soft Sil";
            this.button_PerDelete.UseVisualStyleBackColor = true;
            this.button_PerDelete.Click += new System.EventHandler(this.button_PerDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Şifre";
            this.label1.Visible = false;
            // 
            // radioButton_Status
            // 
            this.radioButton_Status.AutoSize = true;
            this.radioButton_Status.Location = new System.Drawing.Point(374, 95);
            this.radioButton_Status.Name = "radioButton_Status";
            this.radioButton_Status.Size = new System.Drawing.Size(56, 17);
            this.radioButton_Status.TabIndex = 16;
            this.radioButton_Status.TabStop = true;
            this.radioButton_Status.Text = "Durum";
            this.radioButton_Status.UseVisualStyleBackColor = true;
            // 
            // label_KullaniciAd
            // 
            this.label_KullaniciAd.AutoSize = true;
            this.label_KullaniciAd.Location = new System.Drawing.Point(67, 111);
            this.label_KullaniciAd.Name = "label_KullaniciAd";
            this.label_KullaniciAd.Size = new System.Drawing.Size(62, 13);
            this.label_KullaniciAd.TabIndex = 13;
            this.label_KullaniciAd.Text = "Kullanıcı Ad";
            // 
            // textBox_KullaniciAd
            // 
            this.textBox_KullaniciAd.Location = new System.Drawing.Point(150, 104);
            this.textBox_KullaniciAd.Name = "textBox_KullaniciAd";
            this.textBox_KullaniciAd.Size = new System.Drawing.Size(120, 20);
            this.textBox_KullaniciAd.TabIndex = 12;
            // 
            // button_PerUpdate
            // 
            this.button_PerUpdate.Location = new System.Drawing.Point(292, 244);
            this.button_PerUpdate.Name = "button_PerUpdate";
            this.button_PerUpdate.Size = new System.Drawing.Size(75, 23);
            this.button_PerUpdate.TabIndex = 11;
            this.button_PerUpdate.Text = "Güncelle";
            this.button_PerUpdate.UseVisualStyleBackColor = true;
            this.button_PerUpdate.Click += new System.EventHandler(this.button_PerUpdate_Click);
            // 
            // label_Role
            // 
            this.label_Role.AutoSize = true;
            this.label_Role.Location = new System.Drawing.Point(67, 207);
            this.label_Role.Name = "label_Role";
            this.label_Role.Size = new System.Drawing.Size(23, 13);
            this.label_Role.TabIndex = 10;
            this.label_Role.Text = "Rol";
            // 
            // label_Sifre
            // 
            this.label_Sifre.AutoSize = true;
            this.label_Sifre.Location = new System.Drawing.Point(78, 165);
            this.label_Sifre.Name = "label_Sifre";
            this.label_Sifre.Size = new System.Drawing.Size(28, 13);
            this.label_Sifre.TabIndex = 9;
            this.label_Sifre.Text = "Şifre";
            // 
            // label_AdSoyad
            // 
            this.label_AdSoyad.AutoSize = true;
            this.label_AdSoyad.Location = new System.Drawing.Point(67, 43);
            this.label_AdSoyad.Name = "label_AdSoyad";
            this.label_AdSoyad.Size = new System.Drawing.Size(50, 13);
            this.label_AdSoyad.TabIndex = 8;
            this.label_AdSoyad.Text = "AdSoyad";
            // 
            // comboBox_RolSecim
            // 
            this.comboBox_RolSecim.FormattingEnabled = true;
            this.comboBox_RolSecim.Location = new System.Drawing.Point(140, 199);
            this.comboBox_RolSecim.Name = "comboBox_RolSecim";
            this.comboBox_RolSecim.Size = new System.Drawing.Size(177, 21);
            this.comboBox_RolSecim.TabIndex = 7;
            // 
            // dataGridViewKullanıcıList
            // 
            this.dataGridViewKullanıcıList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKullanıcıList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewKullanıcıList.Location = new System.Drawing.Point(3, 308);
            this.dataGridViewKullanıcıList.Name = "dataGridViewKullanıcıList";
            this.dataGridViewKullanıcıList.Size = new System.Drawing.Size(1017, 181);
            this.dataGridViewKullanıcıList.TabIndex = 6;
            this.dataGridViewKullanıcıList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PerDataGridView_CellDoubleClick);
            // 
            // textBox_Sifre
            // 
            this.textBox_Sifre.Location = new System.Drawing.Point(150, 162);
            this.textBox_Sifre.Name = "textBox_Sifre";
            this.textBox_Sifre.Size = new System.Drawing.Size(120, 20);
            this.textBox_Sifre.TabIndex = 5;
            // 
            // button_PerKayit
            // 
            this.button_PerKayit.Location = new System.Drawing.Point(195, 244);
            this.button_PerKayit.Name = "button_PerKayit";
            this.button_PerKayit.Size = new System.Drawing.Size(75, 23);
            this.button_PerKayit.TabIndex = 4;
            this.button_PerKayit.Text = "Kayıt Yap";
            this.button_PerKayit.UseVisualStyleBackColor = true;
            this.button_PerKayit.Click += new System.EventHandler(this.button_PerKayit_Click);
            // 
            // textBox_AdSoyad
            // 
            this.textBox_AdSoyad.Location = new System.Drawing.Point(150, 36);
            this.textBox_AdSoyad.Name = "textBox_AdSoyad";
            this.textBox_AdSoyad.Size = new System.Drawing.Size(120, 20);
            this.textBox_AdSoyad.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button_LotSil);
            this.tabPage3.Controls.Add(this.button_LotGuncelle);
            this.tabPage3.Controls.Add(this.button_LotKayit);
            this.tabPage3.Controls.Add(this.comboBox_UrunLot);
            this.tabPage3.Controls.Add(this.textBox_LotNo);
            this.tabPage3.Controls.Add(this.label_LotNo);
            this.tabPage3.Controls.Add(this.label_UrunID);
            this.tabPage3.Controls.Add(this.dataGridView_LotList);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1023, 492);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lot İşlem";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button_LotSil
            // 
            this.button_LotSil.Location = new System.Drawing.Point(342, 155);
            this.button_LotSil.Name = "button_LotSil";
            this.button_LotSil.Size = new System.Drawing.Size(75, 23);
            this.button_LotSil.TabIndex = 21;
            this.button_LotSil.Text = "Kalıcı Sil";
            this.button_LotSil.UseVisualStyleBackColor = true;
            this.button_LotSil.Click += new System.EventHandler(this.button_LotSil_Click);
            // 
            // button_LotGuncelle
            // 
            this.button_LotGuncelle.Location = new System.Drawing.Point(231, 155);
            this.button_LotGuncelle.Name = "button_LotGuncelle";
            this.button_LotGuncelle.Size = new System.Drawing.Size(75, 23);
            this.button_LotGuncelle.TabIndex = 20;
            this.button_LotGuncelle.Text = "Güncelle";
            this.button_LotGuncelle.UseVisualStyleBackColor = true;
            this.button_LotGuncelle.Click += new System.EventHandler(this.button_LotGuncelle_Click);
            // 
            // button_LotKayit
            // 
            this.button_LotKayit.Location = new System.Drawing.Point(134, 155);
            this.button_LotKayit.Name = "button_LotKayit";
            this.button_LotKayit.Size = new System.Drawing.Size(75, 23);
            this.button_LotKayit.TabIndex = 19;
            this.button_LotKayit.Text = "Kayıt Yap";
            this.button_LotKayit.UseVisualStyleBackColor = true;
            this.button_LotKayit.Click += new System.EventHandler(this.button_LotKayit_Click);
            // 
            // comboBox_UrunLot
            // 
            this.comboBox_UrunLot.FormattingEnabled = true;
            this.comboBox_UrunLot.Location = new System.Drawing.Point(150, 81);
            this.comboBox_UrunLot.Name = "comboBox_UrunLot";
            this.comboBox_UrunLot.Size = new System.Drawing.Size(121, 21);
            this.comboBox_UrunLot.TabIndex = 4;
            this.comboBox_UrunLot.Click += new System.EventHandler(this.comboBox_UrunLot_Click);
            // 
            // textBox_LotNo
            // 
            this.textBox_LotNo.Location = new System.Drawing.Point(150, 41);
            this.textBox_LotNo.Name = "textBox_LotNo";
            this.textBox_LotNo.Size = new System.Drawing.Size(100, 20);
            this.textBox_LotNo.TabIndex = 3;
            // 
            // label_LotNo
            // 
            this.label_LotNo.AutoSize = true;
            this.label_LotNo.Location = new System.Drawing.Point(80, 44);
            this.label_LotNo.Name = "label_LotNo";
            this.label_LotNo.Size = new System.Drawing.Size(39, 13);
            this.label_LotNo.TabIndex = 2;
            this.label_LotNo.Text = "Lot No";
            // 
            // label_UrunID
            // 
            this.label_UrunID.AutoSize = true;
            this.label_UrunID.Location = new System.Drawing.Point(80, 84);
            this.label_UrunID.Name = "label_UrunID";
            this.label_UrunID.Size = new System.Drawing.Size(30, 13);
            this.label_UrunID.TabIndex = 1;
            this.label_UrunID.Text = "Urun";
            // 
            // dataGridView_LotList
            // 
            this.dataGridView_LotList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LotList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_LotList.Location = new System.Drawing.Point(3, 339);
            this.dataGridView_LotList.Name = "dataGridView_LotList";
            this.dataGridView_LotList.Size = new System.Drawing.Size(1017, 150);
            this.dataGridView_LotList.TabIndex = 0;
            this.dataGridView_LotList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LotDataGridView_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Islem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 518);
            this.Controls.Add(this.tabControl1);
            this.Name = "Islem";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.PersonelIslem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UrunList)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanıcıList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LotList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_PerKayit;
        private System.Windows.Forms.TextBox textBox_AdSoyad;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridViewKullanıcıList;
        private System.Windows.Forms.TextBox textBox_Sifre;
        private System.Windows.Forms.ComboBox comboBox_RolSecim;
        private System.Windows.Forms.Label label_Role;
        private System.Windows.Forms.Label label_Sifre;
        private System.Windows.Forms.Label label_AdSoyad;
        private System.Windows.Forms.Button button_PerUpdate;
        private System.Windows.Forms.Label label_KullaniciAd;
        private System.Windows.Forms.TextBox textBox_KullaniciAd;
        private System.Windows.Forms.RadioButton radioButton_Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_PerDelete;
        private System.Windows.Forms.DataGridView dataGridView_UrunList;
        private System.Windows.Forms.Label label_UrunAdi;
        private System.Windows.Forms.TextBox textBox_UrunAdi;
        private System.Windows.Forms.Label label_UrunKod;
        private System.Windows.Forms.TextBox textBox_UrunKod;
        private System.Windows.Forms.Button button_UrunSil;
        private System.Windows.Forms.Button button_UrunGuncelle;
        private System.Windows.Forms.Button button_UrunKayit;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBox_UrunLot;
        private System.Windows.Forms.TextBox textBox_LotNo;
        private System.Windows.Forms.Label label_LotNo;
        private System.Windows.Forms.Label label_UrunID;
        private System.Windows.Forms.DataGridView dataGridView_LotList;
        private System.Windows.Forms.Button button_LotSil;
        private System.Windows.Forms.Button button_LotGuncelle;
        private System.Windows.Forms.Button button_LotKayit;
        private System.Windows.Forms.Button button_KaliciSil;
    }
}