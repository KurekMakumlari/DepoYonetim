namespace DepoYonetim.Forms
{
    partial class PersonelIslem
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox_RolSecim = new System.Windows.Forms.ComboBox();
            this.dataGridViewKullanıcıList = new System.Windows.Forms.DataGridView();
            this.textBox_Sifre = new System.Windows.Forms.TextBox();
            this.button_Kayit = new System.Windows.Forms.Button();
            this.textBox_AdSoyad = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label_AdSoyad = new System.Windows.Forms.Label();
            this.label_Sifre = new System.Windows.Forms.Label();
            this.label_Role = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanıcıList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 518);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1023, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_Role);
            this.tabPage1.Controls.Add(this.label_Sifre);
            this.tabPage1.Controls.Add(this.label_AdSoyad);
            this.tabPage1.Controls.Add(this.comboBox_RolSecim);
            this.tabPage1.Controls.Add(this.dataGridViewKullanıcıList);
            this.tabPage1.Controls.Add(this.textBox_Sifre);
            this.tabPage1.Controls.Add(this.button_Kayit);
            this.tabPage1.Controls.Add(this.textBox_AdSoyad);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1023, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox_RolSecim
            // 
            this.comboBox_RolSecim.FormattingEnabled = true;
            this.comboBox_RolSecim.Location = new System.Drawing.Point(140, 199);
            this.comboBox_RolSecim.Name = "comboBox_RolSecim";
            this.comboBox_RolSecim.Size = new System.Drawing.Size(177, 21);
            this.comboBox_RolSecim.TabIndex = 7;
            this.comboBox_RolSecim.Click += new System.EventHandler(this.ComboBoxClick_RolSecim);
            // 
            // dataGridViewKullanıcıList
            // 
            this.dataGridViewKullanıcıList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKullanıcıList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewKullanıcıList.Location = new System.Drawing.Point(3, 308);
            this.dataGridViewKullanıcıList.Name = "dataGridViewKullanıcıList";
            this.dataGridViewKullanıcıList.Size = new System.Drawing.Size(1017, 181);
            this.dataGridViewKullanıcıList.TabIndex = 6;
            this.dataGridViewKullanıcıList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox_Sifre
            // 
            this.textBox_Sifre.Location = new System.Drawing.Point(150, 162);
            this.textBox_Sifre.Name = "textBox_Sifre";
            this.textBox_Sifre.Size = new System.Drawing.Size(120, 20);
            this.textBox_Sifre.TabIndex = 5;
            // 
            // button_Kayit
            // 
            this.button_Kayit.Location = new System.Drawing.Point(195, 244);
            this.button_Kayit.Name = "button_Kayit";
            this.button_Kayit.Size = new System.Drawing.Size(75, 23);
            this.button_Kayit.TabIndex = 4;
            this.button_Kayit.Text = "Kayıt Yap";
            this.button_Kayit.UseVisualStyleBackColor = true;
            this.button_Kayit.Click += new System.EventHandler(this.button_Kayit_Click);
            // 
            // textBox_AdSoyad
            // 
            this.textBox_AdSoyad.Location = new System.Drawing.Point(150, 112);
            this.textBox_AdSoyad.Name = "textBox_AdSoyad";
            this.textBox_AdSoyad.Size = new System.Drawing.Size(120, 20);
            this.textBox_AdSoyad.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label_AdSoyad
            // 
            this.label_AdSoyad.AutoSize = true;
            this.label_AdSoyad.Location = new System.Drawing.Point(67, 119);
            this.label_AdSoyad.Name = "label_AdSoyad";
            this.label_AdSoyad.Size = new System.Drawing.Size(50, 13);
            this.label_AdSoyad.TabIndex = 8;
            this.label_AdSoyad.Text = "AdSoyad";
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
            // label_Role
            // 
            this.label_Role.AutoSize = true;
            this.label_Role.Location = new System.Drawing.Point(67, 207);
            this.label_Role.Name = "label_Role";
            this.label_Role.Size = new System.Drawing.Size(23, 13);
            this.label_Role.TabIndex = 10;
            this.label_Role.Text = "Rol";
            // 
            // PersonelIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 518);
            this.Controls.Add(this.tabControl1);
            this.Name = "PersonelIslem";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.PersonelIslem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanıcıList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_Kayit;
        private System.Windows.Forms.TextBox textBox_AdSoyad;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridViewKullanıcıList;
        private System.Windows.Forms.TextBox textBox_Sifre;
        private System.Windows.Forms.ComboBox comboBox_RolSecim;
        private System.Windows.Forms.Label label_Role;
        private System.Windows.Forms.Label label_Sifre;
        private System.Windows.Forms.Label label_AdSoyad;
    }
}