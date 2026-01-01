using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Core.Enums;

namespace DepoYonetim.Forms
{
    public partial class Islem : Form
    {
        public Islem() => InitializeComponent();

        Repository Repo = new Repository("Data Source=.\\SQLEXPRESS01;Initial Catalog=DepoYonetimi;Integrated Security=True;");
        private void PersonelIslem_Load(object sender, EventArgs e)
        {
            textBox_AdSoyad.Focus();
            PersonelDataGridViewListeleme();
            UrunDataGridViewListeleme();
        }
        #region Personel
        private void PerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_AdSoyad.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["AdSoyad"].Value.ToString();
            textBox_Sifre.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["SifreHash"].Value.ToString();
            textBox_KullaniciAd.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["KullaniciAdi"].Value.ToString();
            textBox_RoleID.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["RoleID"].Value.ToString();
            label1.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["Status"].Value.ToString();
            radioButton_Status.Checked = label1.Text == "True" ? true : false;
        }

        private void ComboBoxClick_RolSecim(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.GetByData("SELECT * FROM Tbl_Role");
            if (state == State.Success)
            {
                comboBox_RolSecim.DataSource = dt;
                comboBox_RolSecim.DisplayMember = "RoleName";
                comboBox_RolSecim.ValueMember = "Id";
            }
            else MessageBox.Show("Veri çekme işlemi başarısız: " + message);
        }

        private void button_PerKayit_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.ExecuteSql("INSERT INTO Tbl_Kullanici (AdSoyad,SifreHash,RoleID,KullaniciAdi) VALUES ('" + textBox_AdSoyad.Text + "','" + textBox_Sifre.Text + "'," + comboBox_RolSecim.SelectedValue + ",'" + textBox_KullaniciAd.Text + "')", null);

            #region Islemin Basarılı Olma Basarısız Olma Durumu
            if (state == State.Success) MessageBox.Show("Kullanıcı başarıyla eklendi.");
            else MessageBox.Show("Kullanıcı ekleme işlemi başarısız: " + message);
            #endregion

            PersonelDataGridViewListeleme();
        }
        private void button_PerUpdate_Click(object sender, EventArgs e)
        {
            int StatuNo = radioButton_Status.Checked ? 1 : 0;
            var (dt, state, message) = Repo.ExecuteSql("UPDATE Tbl_Kullanici SET AdSoyad='" + textBox_AdSoyad.Text + "', SifreHash='" + textBox_Sifre.Text + "', KullaniciAdi='" + textBox_KullaniciAd.Text + "', RoleID=" + comboBox_RolSecim.SelectedIndex + ", Status=" + StatuNo + " WHERE ID=" + dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString(), null);

            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show = state == State.Success ? "Kullanıcı başarıyla güncellendi." : "Kullanıcı güncelleme işlemi başarısız: " + message;
            MessageBox.Show(Show);
            #endregion

            PersonelDataGridViewListeleme();

        }
        private void button_PerDelete_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.ExecuteSql("DELETE FROM Tbl_Kullanici WHERE ID=" + dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["ID"].Value, null);

            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show = state == State.Success ? "Kullanıcı başarıyla silindi." : "Kullanıcı silme işlemi başarısız: " + message;
            MessageBox.Show(Show);
            #endregion
            PersonelDataGridViewListeleme();
        }
        public void PersonelDataGridViewListeleme()
        {
            var (dt, state, message) = Repo.GetByData("SELECT * FROM Tbl_Kullanici");
            if (state == State.Success)
            {
                dataGridViewKullanıcıList.DataSource = dt;
            }
            else MessageBox.Show("Veri çekme işlemi başarısız: " + message);
        }
        #endregion

        //Urun Sayfası Başlangıcı




        private void UrunDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_UrunAdi.Text = dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["UrunAdi"].Value.ToString();
            textBox_UrunKod.Text = dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["UrunKod"].Value.ToString();
        }

        private void button_UrunKayit_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.ExecuteSql("INSERT INTO Tbl_Urun (UrunAdi,UrunKod) VALUES ('" + textBox_UrunAdi.Text + "','" + textBox_UrunKod.Text + "')", null);
            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show2 = state == State.Success ? "Urun başarıyla eklendi." : "Urun  ekleme işlemi başarısız: " + message;
            MessageBox.Show(Show2);
            #endregion
            UrunDataGridViewListeleme();
        }

        private void button_UrunGuncelle_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.ExecuteSql("UPDATE Tbl_Urun SET UrunAdi='" + textBox_UrunAdi.Text + "', UrunKod='" + textBox_UrunKod.Text + "' WHERE ID=" + dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString(), null);
            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show3 = state == State.Success ? "Urun başarıyla güncellendi." : "Urun güncelleme işlemi başarısız: " + message;
            MessageBox.Show(Show3);
            #endregion
            UrunDataGridViewListeleme();
        }
        private void button_UrunSil_Click(object sender, EventArgs e)
        {
            var ( dt, state, message) = Repo.ExecuteSql("DELETE FROM Tbl_Urun WHERE ID=" + dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["ID"].Value, null);
            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show4 = state == State.Success ? "Urun başarıyla silindi." : "Urun silme işlemi başarısız: " + message;
            MessageBox.Show(Show4);
            #endregion
            UrunDataGridViewListeleme();
        }

        public void UrunDataGridViewListeleme()
        {

            var (dt, state, message) = Repo.GetByData("SELECT * FROM Tbl_Urun");
            if (state == State.Success)
            {
                dataGridView_UrunList.DataSource = dt;
            }
            else MessageBox.Show("Veri çekme işlemi başarısız: " + message);
        }

        
    }
}
