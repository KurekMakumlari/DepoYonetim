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
using DepoYonetim.Aplication;
using BCrypt.Net;
using System.Diagnostics.Eventing.Reader;
using DepoYonetim.Models.Entities;

namespace DepoYonetim.Forms
{
    public partial class Islem : Form
    {
        public Islem() => InitializeComponent();

        Repository Repo = new Repository("Data Source=.\\SQLEXPRESS01;Initial Catalog=DepoYonetimi;Integrated Security=True;");
        PersonelRolMenager _personelRolMenager;

        int personelId;
        private void PersonelIslem_Load(object sender, EventArgs e)
        {
            _personelRolMenager = new PersonelRolMenager(Repo);
            RolGetir();
            textBox_AdSoyad.Focus();
            PersonelDataGridViewListeleme();
            UrunDataGridViewListeleme();
            LotDataGridViewListeleme();
        }
        #region Personel
        private void PerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_AdSoyad.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["AdSoyad"].Value.ToString();
            personelId = Convert.ToInt32(dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
            textBox_KullaniciAd.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["KullaniciAdi"].Value.ToString();
            comboBox_RolSecim.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["RoleName"].Value.ToString();
            label1.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["Status"].Value.ToString();
            radioButton_Status.Checked = label1.Text == "True" ? true : false;
        }

        private void button_PerKayit_Click(object sender, EventArgs e)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(textBox_Sifre.Text);
            var Rol = _personelRolMenager.GetRoleByRoleName(comboBox_RolSecim.SelectedItem.ToString());

            TblKullanici kul = new TblKullanici();
            kul.AdSoyad = textBox_AdSoyad.Text;
            kul.KullaniciAdi = textBox_KullaniciAd.Text;
            kul.SifreHash = passwordHash;
            kul.RoleID = Rol.ID;
            kul.Status = radioButton_Status.Checked ? true : false;
            bool isSave = _personelRolMenager.PersonelKaydet(kul);

            DialogResult result = isSave ? MessageBox.Show("Kullanıcı Kaydı Başarılı Olmuştur.") : MessageBox.Show("Kullanıcı Kaydı Başarısız Olmuştur.");


            PersonelDataGridViewListeleme();
        }
        private void button_PerUpdate_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Kullanıcı bilgilerini güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return; // Kullanıcı hayır dedi, işlemi iptal et
            }

            var personel = _personelRolMenager.GetPersonelById(personelId);

            if (personel != null)
            {
                personel.AdSoyad = textBox_AdSoyad.Text;
                personel.KullaniciAdi = textBox_KullaniciAd.Text;
                personel.SifreHash = !string.IsNullOrEmpty(textBox_Sifre.Text) ? BCrypt.Net.BCrypt.HashPassword(textBox_Sifre.Text) : personel.SifreHash;
                var Rol = _personelRolMenager.GetRoleByRoleName(comboBox_RolSecim.SelectedItem.ToString());
                personel.RoleID = Rol.ID;
                personel.Status = radioButton_Status.Checked ? true : false;
                bool isUpdate = _personelRolMenager.PersonelGuncelle(personel);
                DialogResult result = isUpdate ? MessageBox.Show("Kullanıcı Güncelleme Başarılı Olmuştur.") : MessageBox.Show("Kullanıcı Güncelleme Başarısız Olmuştur.");
                PersonelDataGridViewListeleme();
            }
            else MessageBox.Show("Güncellenecek kullanıcı bulunamadı.");
        }
        private void button_PerDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return; // Kullanıcı hayır dedi, işlemi iptal et
            }
            bool isDelete = _personelRolMenager.PersonelSoftSil(personelId);
            DialogResult result = isDelete ? MessageBox.Show("Kullanıcı Silme Başarılı Olmuştur.") : MessageBox.Show("Kullanıcı Silme Başarısız Olmuştur.");

            PersonelDataGridViewListeleme();
        }
        private void button_KaliciSil_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Kullanıcıyı kalıcı olarak silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return; // Kullanıcı hayır dedi, işlemi iptal et
            }
            bool isDelete = _personelRolMenager.PersonelKaldir(personelId);
            DialogResult result = isDelete ? MessageBox.Show("Kullanıcı Kalıcı Silme Başarılı Olmuştur.") : MessageBox.Show("Kullanıcı Kalıcı Silme Başarısız Olmuştur.");
        }
        public void PersonelDataGridViewListeleme()
        {
            //var (dt, state, message) = Repo.GetByData("SELECT * FROM Tbl_Kullanici");
            //if (state == State.Success)
            //{
            //    dataGridViewKullanıcıList.DataSource = dt;
            //}
            //else MessageBox.Show("Veri çekme işlemi başarısız: " + message);
            PersonelRolGetir();
        }
        #endregion

        #region Urun
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
            var (dt, state, message) = Repo.ExecuteSql("DELETE FROM Tbl_Urun WHERE ID=" + dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["ID"].Value, null);
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
        #endregion

        #region Lot
        private void LotDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_LotNo.Text = dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["LotNo"].Value.ToString();
            comboBox_UrunLot.Text = dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["UrunAdi"].Value.ToString();
        }

        private void button_LotKayit_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.ExecuteSql("INSERT INTO Tbl_Lot (LotNo,UrunID) VALUES ('" + textBox_LotNo.Text + "'," + comboBox_UrunLot.SelectedValue + ")", null);
            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show5 = state == State.Success ? "Lot başarıyla eklendi." : "Lot ekleme işlemi başarısız: " + message;
            MessageBox.Show(Show5);
            #endregion
            LotDataGridViewListeleme();
        }

        private void button_LotGuncelle_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.ExecuteSql("UPDATE Tbl_Lot SET LotNo='" + textBox_LotNo.Text + "', UrunID=" + comboBox_UrunLot.SelectedValue + " WHERE ID=" + dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString(), null);
            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show6 = state == State.Success ? "Lot başarıyla güncellendi." : "Lot güncelleme işlemi başarısız: " + message;
            MessageBox.Show(Show6);
            #endregion
            LotDataGridViewListeleme();
        }

        private void button_LotSil_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.ExecuteSql("DELETE FROM Tbl_Lot WHERE ID=" + dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["ID"].Value, null);
            #region Islemin Basarılı Olma Basarısız Olma Durumu
            string Show7 = state == State.Success ? "Lot başarıyla silindi." : "Lot silme işlemi başarısız: " + message;
            MessageBox.Show(Show7);
            #endregion
            LotDataGridViewListeleme();
        }
        private void comboBox_UrunLot_Click(object sender, EventArgs e)
        {
            var (dt, state, message) = Repo.GetByData("SELECT * FROM Tbl_Urun");
            if (state == State.Success)
            {
                comboBox_UrunLot.DataSource = dt;
                comboBox_UrunLot.DisplayMember = "UrunAdi";
                comboBox_UrunLot.ValueMember = "ID";
            }
            else MessageBox.Show("Veri çekme işlemi başarısız: " + message);

        }
        public void LotDataGridViewListeleme()
        {

            var (dt, state, message) = Repo.GetByData("SELECT * FROM vw_UrunLot");
            if (state == State.Success)
            {
                dataGridView_LotList.DataSource = dt;
            }
            else MessageBox.Show("Veri çekme işlemi başarısız: " + message);
        }


        #endregion

        public void ClearAllFields()
        {
            // Personel sekmesi
            textBox_AdSoyad.Clear();
            textBox_Sifre.Clear();
            textBox_KullaniciAd.Clear();
            comboBox_RolSecim.SelectedIndex = -1;
            radioButton_Status.Checked = false;
            // Ürün sekmesi
            textBox_UrunAdi.Clear();
            textBox_UrunKod.Clear();
            // Lot sekmesi
            textBox_LotNo.Clear();
            comboBox_UrunLot.SelectedIndex = -1;
        }

        public void PersonelRolGetir()
        {
            dataGridViewKullanıcıList.DataSource = _personelRolMenager.GetAllPersonelRol();
        }

        public void RolGetir()
        {
            if (comboBox_RolSecim.Items.Count > 0)
            {
                comboBox_RolSecim.Items.Clear();
            }

            comboBox_RolSecim.Items.AddRange(_personelRolMenager.GetAllRoles().Select(r => r.RoleName).ToArray());
        }


    }
}
