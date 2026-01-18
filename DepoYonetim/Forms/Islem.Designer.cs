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
            this.TabPages = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_UrunSoftSil = new System.Windows.Forms.Button();
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
            this.button_LotSoftSil = new System.Windows.Forms.Button();
            this.button_LotKaliciSil = new System.Windows.Forms.Button();
            this.button_LotGuncelle = new System.Windows.Forms.Button();
            this.button_LotKayit = new System.Windows.Forms.Button();
            this.comboBox_UrunLot = new System.Windows.Forms.ComboBox();
            this.textBox_LotNo = new System.Windows.Forms.TextBox();
            this.label_LotNo = new System.Windows.Forms.Label();
            this.label_UrunID = new System.Windows.Forms.Label();
            this.dataGridView_LotList = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label_UrunKodRead = new System.Windows.Forms.Label();
            this.label_UrunAd = new System.Windows.Forms.Label();
            this.label_LotVar = new System.Windows.Forms.Label();
            this.dataGridView_Uretilen = new System.Windows.Forms.DataGridView();
            this.textBox_LotNoWrite = new System.Windows.Forms.TextBox();
            this.button_UretimBaslat = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox_LotNoRead = new System.Windows.Forms.TextBox();
            this.TabPages.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UrunList)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanıcıList)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LotList)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Uretilen)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPages
            // 
            this.TabPages.Controls.Add(this.tabPage2);
            this.TabPages.Controls.Add(this.tabPage1);
            this.TabPages.Controls.Add(this.tabPage3);
            this.TabPages.Controls.Add(this.tabPage4);
            this.TabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPages.Location = new System.Drawing.Point(0, 0);
            this.TabPages.Name = "TabPages";
            this.TabPages.SelectedIndex = 0;
            this.TabPages.Size = new System.Drawing.Size(1031, 518);
            this.TabPages.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_UrunSoftSil);
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
            // button_UrunSoftSil
            // 
            this.button_UrunSoftSil.Location = new System.Drawing.Point(348, 186);
            this.button_UrunSoftSil.Name = "button_UrunSoftSil";
            this.button_UrunSoftSil.Size = new System.Drawing.Size(75, 23);
            this.button_UrunSoftSil.TabIndex = 22;
            this.button_UrunSoftSil.Text = "Soft Sil";
            this.button_UrunSoftSil.UseVisualStyleBackColor = true;
            this.button_UrunSoftSil.Click += new System.EventHandler(this.button_UrunSoftSil_Click);
            // 
            // button_UrunSil
            // 
            this.button_UrunSil.Location = new System.Drawing.Point(474, 186);
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
            this.dataGridView_UrunList.RowTemplate.ReadOnly = true;
            this.dataGridView_UrunList.Size = new System.Drawing.Size(1017, 200);
            this.dataGridView_UrunList.TabIndex = 0;
            this.dataGridView_UrunList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UrunDataGridView_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_KaliciSil);
            this.tabPage1.Controls.Add(this.button_PerDelete);
            this.tabPage1.Controls.Add(this.label1);
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
            this.tabPage3.Controls.Add(this.button_LotSoftSil);
            this.tabPage3.Controls.Add(this.button_LotKaliciSil);
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
            // button_LotSoftSil
            // 
            this.button_LotSoftSil.Location = new System.Drawing.Point(329, 155);
            this.button_LotSoftSil.Name = "button_LotSoftSil";
            this.button_LotSoftSil.Size = new System.Drawing.Size(75, 23);
            this.button_LotSoftSil.TabIndex = 23;
            this.button_LotSoftSil.Text = "Soft Sil";
            this.button_LotSoftSil.UseVisualStyleBackColor = true;
            this.button_LotSoftSil.Click += new System.EventHandler(this.button_LotSoftSil_Click);
            // 
            // button_LotKaliciSil
            // 
            this.button_LotKaliciSil.Location = new System.Drawing.Point(410, 155);
            this.button_LotKaliciSil.Name = "button_LotKaliciSil";
            this.button_LotKaliciSil.Size = new System.Drawing.Size(75, 23);
            this.button_LotKaliciSil.TabIndex = 21;
            this.button_LotKaliciSil.Text = "Kalıcı Sil";
            this.button_LotKaliciSil.UseVisualStyleBackColor = true;
            this.button_LotKaliciSil.Click += new System.EventHandler(this.button_LotKaliciSil_Click);
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBox_LotNoRead);
            this.tabPage4.Controls.Add(this.label_UrunKodRead);
            this.tabPage4.Controls.Add(this.label_UrunAd);
            this.tabPage4.Controls.Add(this.label_LotVar);
            this.tabPage4.Controls.Add(this.dataGridView_Uretilen);
            this.tabPage4.Controls.Add(this.textBox_LotNoWrite);
            this.tabPage4.Controls.Add(this.button_UretimBaslat);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1023, 492);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Uretim";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label_UrunKodRead
            // 
            this.label_UrunKodRead.AutoSize = true;
            this.label_UrunKodRead.Location = new System.Drawing.Point(659, 88);
            this.label_UrunKodRead.Name = "label_UrunKodRead";
            this.label_UrunKodRead.Size = new System.Drawing.Size(60, 24);
            this.label_UrunKodRead.TabIndex = 6;
            this.label_UrunKodRead.Text = "_____";
            // 
            // label_UrunAd
            // 
            this.label_UrunAd.AutoSize = true;
            this.label_UrunAd.Location = new System.Drawing.Point(502, 88);
            this.label_UrunAd.Name = "label_UrunAd";
            this.label_UrunAd.Size = new System.Drawing.Size(60, 24);
            this.label_UrunAd.TabIndex = 5;
            this.label_UrunAd.Text = "_____";
            // 
            // label_LotVar
            // 
            this.label_LotVar.AutoSize = true;
            this.label_LotVar.Location = new System.Drawing.Point(345, 88);
            this.label_LotVar.Name = "label_LotVar";
            this.label_LotVar.Size = new System.Drawing.Size(60, 24);
            this.label_LotVar.TabIndex = 4;
            this.label_LotVar.Text = "_____";
            // 
            // dataGridView_Uretilen
            // 
            this.dataGridView_Uretilen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Uretilen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_Uretilen.Location = new System.Drawing.Point(3, 339);
            this.dataGridView_Uretilen.Name = "dataGridView_Uretilen";
            this.dataGridView_Uretilen.Size = new System.Drawing.Size(1017, 150);
            this.dataGridView_Uretilen.TabIndex = 3;
            // 
            // textBox_LotNoWrite
            // 
            this.textBox_LotNoWrite.Location = new System.Drawing.Point(76, 86);
            this.textBox_LotNoWrite.Name = "textBox_LotNoWrite";
            this.textBox_LotNoWrite.Size = new System.Drawing.Size(172, 29);
            this.textBox_LotNoWrite.TabIndex = 1;
            // 
            // button_UretimBaslat
            // 
            this.button_UretimBaslat.Location = new System.Drawing.Point(816, 83);
            this.button_UretimBaslat.Name = "button_UretimBaslat";
            this.button_UretimBaslat.Size = new System.Drawing.Size(82, 37);
            this.button_UretimBaslat.TabIndex = 0;
            this.button_UretimBaslat.Text = "Baslat";
            this.button_UretimBaslat.UseVisualStyleBackColor = true;
            this.button_UretimBaslat.Click += new System.EventHandler(this.button_UretimBaslat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox_LotNoRead
            // 
            this.textBox_LotNoRead.Location = new System.Drawing.Point(76, 24);
            this.textBox_LotNoRead.Name = "textBox_LotNoRead";
            this.textBox_LotNoRead.Size = new System.Drawing.Size(172, 29);
            this.textBox_LotNoRead.TabIndex = 7;
            // 
            // Islem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 518);
            this.Controls.Add(this.TabPages);
            this.Name = "Islem";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.PersonelIslem_Load);
            this.TabPages.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UrunList)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanıcıList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LotList)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Uretilen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabPages;
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
        private System.Windows.Forms.Button button_LotKaliciSil;
        private System.Windows.Forms.Button button_LotGuncelle;
        private System.Windows.Forms.Button button_LotKayit;
        private System.Windows.Forms.Button button_KaliciSil;
        private System.Windows.Forms.Button button_UrunSoftSil;
        private System.Windows.Forms.Button button_LotSoftSil;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox_LotNoWrite;
        private System.Windows.Forms.Button button_UretimBaslat;
        private System.Windows.Forms.DataGridView dataGridView_Uretilen;
        private System.Windows.Forms.Label label_UrunKodRead;
        private System.Windows.Forms.Label label_UrunAd;
        private System.Windows.Forms.Label label_LotVar;
        private System.Windows.Forms.TextBox textBox_LotNoRead;
    }
}