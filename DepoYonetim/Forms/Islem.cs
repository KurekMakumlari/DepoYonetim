using BCrypt.Net;
using DepoYonetim.Aplication;
using DepoYonetim.Core.Enums;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoYonetim.Forms
{
    public partial class Islem : Form
    {
        public Islem() => InitializeComponent();

        Repository Repo = new Repository("Data Source=.\\SQLEXPRESS01;Initial Catalog=DepoYonetimi;Integrated Security=True;");
        PersonelRolMenager _personelRolMenager;
        LotUrunMenager _urunLotMenager;

        int personelId;
        int lotId;
        private void PersonelIslem_Load(object sender, EventArgs e)
        {
            textBox_AdSoyad.Focus();

            _personelRolMenager = new PersonelRolMenager(Repo);
            _urunLotMenager = new LotUrunMenager(Repo);

            RolGetir();
            UrunNameGetir();

            PersonelRolGetir();
            LotUrunGetir();
        }
        #region Personel
        private void PerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_AdSoyad.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["AdSoyad"].Value.ToString();
            personelId = Convert.ToInt32(dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
            textBox_KullaniciAd.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["KullaniciAdi"].Value.ToString();
            comboBox_RolSecim.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["RoleName"].Value.ToString();
            label1.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["Status"].Value.ToString();
            checkBox_Status.Checked = label1.Text == "True" ? true : false;
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
            kul.Status = checkBox_Status.Checked ? true : false;
            bool isSave = _personelRolMenager.PersonelKaydet(kul);

            DialogResult result = isSave ? MessageBox.Show("Kullanıcı Kaydı Başarılı Olmuştur.") : MessageBox.Show("Kullanıcı Kaydı Başarısız Olmuştur.");
            PersonelRolGetir();
        }
        private void button_PerUpdate_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Kullanıcı bilgilerini güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No) return;
            {/* Kullanıcı hayır dedi, işlemi iptal et*/}
            // Ürün ID'sini al
            var personel = _personelRolMenager.GetPersonelById(personelId);

            // Ürünü güncelle
            if (personel != null)
            {
                personel.AdSoyad = textBox_AdSoyad.Text;
                personel.KullaniciAdi = textBox_KullaniciAd.Text;
                personel.SifreHash = !string.IsNullOrEmpty(textBox_Sifre.Text) ? BCrypt.Net.BCrypt.HashPassword(textBox_Sifre.Text) : personel.SifreHash;
                var Rol = _personelRolMenager.GetRoleByRoleName(comboBox_RolSecim.SelectedItem.ToString());
                personel.RoleID = Rol.ID;
                personel.Status = checkBox_Status.Checked ? true : false;
                bool isUpdate = _personelRolMenager.PersonelGuncelle(personel);
                DialogResult result = isUpdate ? MessageBox.Show("Kullanıcı Güncelleme Başarılı Olmuştur.") : MessageBox.Show("Kullanıcı Güncelleme Başarısız Olmuştur.");
                PersonelRolGetir();
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

            PersonelRolGetir();
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

        #endregion

        #region Urun
        private void UrunDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_UrunAdi.Text = dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["UrunAdi"].Value.ToString();
            textBox_UrunKod.Text = dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["UrunKod"].Value.ToString();
        }
        private void button_UrunKayit_Click(object sender, EventArgs e)
        {

        }
        private void button_UrunGuncelle_Click(object sender, EventArgs e)
        {
        }
        private void button_UrunSoftSil_Click(object sender, EventArgs e)
        {
        }
        private void button_UrunSil_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Lot
        private void LotDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TblLot LotId = new TblLot();
            LotId.ID = Convert.ToInt32(dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
            textBox_LotNo.Text = dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["LotNo"].Value.ToString();
            comboBox_UrunLot.Text = dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["UrunAdi"].Value.ToString();
        }

        private void button_LotKayit_Click(object sender, EventArgs e)
        {
            _urunLotMenager.LotKaydet(new TblLot
            {
                LotNo = textBox_LotNo.Text,
                UrunID = _urunLotMenager.GetUrunByUrunName(comboBox_UrunLot.SelectedItem.ToString()).ID,
                Status = checkBox_LotStatus.Checked ? true : false
            });

            UrunNameGetir();
        }

        private void button_LotGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Ürün bilgilerini güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No) { return; /* Kullanıcı hayır dedi, işlemi iptal et*/}
            bool İsUpdate = _urunLotMenager.LotGuncelle(new TblLot
            {
                ID = lotId,
                LotNo = textBox_LotNo.Text,
                UrunID = _urunLotMenager.GetUrunByUrunName(comboBox_UrunLot.SelectedItem.ToString()).ID,
                Status = checkBox_LotStatus.Checked ? true : false

            });
            DialogResult result = İsUpdate ? MessageBox.Show("Lot başarıyla güncellendi.") : MessageBox.Show("Lot güncelleme işlemi başarısız.");


            UrunNameGetir();

            #region Alternatif Urun Var MI Yok mu Diye Kontrol Ederek Guncelleme Islemi
            //var urun = _urunLotMenager.GetLotById(urunId);
            //// Ürünü güncelle
            //if (urun != null)
            //{
            //    // Güncelleme işlemi
            //    urun.UrunAdi = textBox_UrunAdi.Text;
            //    urun.UrunKod = textBox_UrunKod.Text;
            //    // Diğer alanlar da güncellenebilir
            //    bool isUpdate = _urunLotMenager.UrunGuncelle(urun);
            //    DialogResult result = isUpdate ? MessageBox.Show("Urun başarıyla güncellendi.") : MessageBox.Show("Urun güncelleme işlemi başarısız.");
            //}
            //else MessageBox.Show("Güncellenecek ürün bulunamadı."); 
            #endregion
        }
        private void button_LotSoftSil_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Lotu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No) { return; /* Kullanıcı hayır dedi, işlemi iptal et*/}
            var KontrolLot = _urunLotMenager.GetLotById(lotId);
            if (KontrolLot == null)
            {
                MessageBox.Show("Silinecek lot bulunamadı.");
                return;
            }
            else
            {
                DialogResult confirmDelete = MessageBox.Show("Lotu kalıcı olarak silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.No)
                {
                    return; // Kullanıcı hayır dedi, işlemi iptal et
                }
                else
                {
                    bool isDelete = _urunLotMenager.LotGuncelle(new TblLot
                    {
                        ID = lotId,
                        LotNo = KontrolLot.LotNo,
                        UrunID = KontrolLot.UrunID,
                        Status = false
                    });
                }

            }
            UrunNameGetir();

        }

        private void button_LotKaliciSil_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Lotu kalıcı olarak silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return; // Kullanıcı hayır dedi, işlemi iptal et
            }
            var result = _urunLotMenager.GetLotById(lotId);
            DialogResult Kontrol = result == null ? MessageBox.Show("Silinecek lot bulunamadı.") : MessageBox.Show("Lot bulunuyor, silme işlemi gerçekleştiriliyor.");
            if (result != null)
            {
                bool isDelete = _urunLotMenager.LotKaliciSil(lotId);
                DialogResult finalResult = isDelete ? MessageBox.Show("Lot Kalıcı Silme Başarılı Olmuştur.") : MessageBox.Show("Lot Kalıcı Silme Başarısız Olmuştur.");
            }
            UrunNameGetir();


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

        #endregion

        public void ClearAllFields()
        {
            // Personel sekmesi
            textBox_AdSoyad.Clear();
            textBox_Sifre.Clear();
            textBox_KullaniciAd.Clear();
            comboBox_RolSecim.SelectedIndex = -1;
            checkBox_Status.Checked = false;
            // Ürün sekmesi
            textBox_UrunAdi.Clear();
            textBox_UrunKod.Clear();
            // Lot sekmesi
            textBox_LotNo.Clear();
            comboBox_UrunLot.SelectedIndex = -1;
        }

        // Personel Rol Listeleme
        public void PersonelRolGetir() => dataGridViewKullanıcıList.DataSource = _personelRolMenager.GetAllPersonelRol();

        // Ürün Lot Listeleme
        public void LotUrunGetir() => dataGridView_LotList.DataSource = _urunLotMenager.GetAllLotUrun();

        public void RolGetir()
        {
            if (comboBox_RolSecim.Items.Count > 0) { comboBox_RolSecim.Items.Clear(); }
            comboBox_RolSecim.Items.AddRange(_personelRolMenager.GetAllRoles().Select(r => r.RoleName).ToArray());
        }

        public void UrunNameGetir()
        {
            if (comboBox_UrunLot.Items.Count > 0) { comboBox_UrunLot.Items.Clear(); }
            comboBox_UrunLot.Items.AddRange(_urunLotMenager.GetAllUrun().Select(u => u.UrunAdi).ToArray());
        }




    }
}
