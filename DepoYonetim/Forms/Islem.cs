using DepoYonetim.Aplication;
using DepoYonetim.Application;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DepoYonetim.Forms
{
    public partial class Islem : Form
    {
        public Islem() => InitializeComponent();


        Repository Repo = new Repository("Data Source=.\\SQLEXPRESS01;Initial Catalog=DepoYonetimi;Integrated Security=True;");
        PersonelRolMenager _personelRolMenager;
        LotUrunMenager _urunLotMenager;
        UrunManager _urunManager;
        Uretim _uretim;
        KoliManager _koliManager;
        int personelId;
        int lotId;
        int urunId;

        private void PersonelIslem_Load(object sender, EventArgs e)
        {
            textBox_AdSoyad.Focus();

            _personelRolMenager = new PersonelRolMenager(Repo);
            _urunLotMenager = new LotUrunMenager(Repo);
            _urunManager = new UrunManager(Repo);
            _uretim = new Uretim(Repo);
            _koliManager = new KoliManager(Repo);

            RolGetir();
            UrunNameGetir();
            PersonelRolGetir();
            LotUrunGetir();
            UrunGetir();
            UrunLotNoGetir();
        }
        #region Personel
        private void PerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_AdSoyad.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["AdSoyad"].Value.ToString();
            personelId = Convert.ToInt32(dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
            textBox_KullaniciAd.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["KullaniciAdi"].Value.ToString();
            comboBox_RolSecim.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["RoleName"].Value.ToString();
            label1.Text = dataGridViewKullanıcıList.Rows[dataGridViewKullanıcıList.SelectedCells[0].RowIndex].Cells["Status"].Value.ToString();
        }
        private void button_PerKayit_Click(object sender, EventArgs e)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(textBox_Sifre.Text);

                var Rol = _personelRolMenager.GetRoleByRoleName(comboBox_RolSecim.SelectedItem.ToString());
                if (Rol == null)
                {
                    MessageBox.Show("Seçilen rol bulunamadı. Lütfen geçerli bir rol seçin.");
                    return;
                }
                TblKullanici kul = new TblKullanici();
                kul.AdSoyad = textBox_AdSoyad.Text;
                kul.KullaniciAdi = textBox_KullaniciAd.Text;
                kul.SifreHash = passwordHash;
                kul.RoleID = Rol.ID;
                kul.Status = true;
                bool isSave = _personelRolMenager.PersonelKaydet(kul);
                DialogResult result = isSave ? MessageBox.Show("Kullanıcı Kaydı Başarılı Olmuştur.") : MessageBox.Show("Kullanıcı Kaydı Başarısız Olmuştur.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");

            }
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

            urunId = Convert.ToInt32(dataGridView_UrunList.Rows[e.RowIndex].Cells["ID"].Value);
            textBox_UrunAdi.Text = dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["UrunAdi"].Value.ToString();
            textBox_UrunKod.Text = dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["UrunKod"].Value.ToString();
            textBox_UrunAgirlik.Text = dataGridView_UrunList.Rows[dataGridView_UrunList.SelectedCells[0].RowIndex].Cells["BirimAgirlik"].Value.ToString();


        }
        private void button_UrunKayit_Click(object sender, EventArgs e)
        {
            var KayıtUrunler = _urunManager.GetAllUrun();
            if (KayıtUrunler.Any(x => x.UrunKod == textBox_UrunKod.Text)) throw new Exception("Bu ürün kodu zaten kayıtlı.");

            bool Result = _urunManager.UrunKaydet(new TblUrun
            {
                UrunKod = textBox_UrunKod.Text,
                UrunAdi = textBox_UrunAdi.Text,
                BirimAgirlik = textBox_UrunAgirlik.Text,
                Status = true
            });

            UrunGetir();
        }
        private void button_UrunGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Ürün bilgilerini güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Ürün ID'sini al
                var KontrolUrun = _urunManager.GetUrunById(urunId);
                // Güncellenecek ürünün varlığını kontrol et
                if (KontrolUrun == null)
                {
                    MessageBox.Show("Güncellenecek ürün bulunamadı.");
                    return;
                }
                // Alanların boş olup olmadığını kontrol et
                if (string.IsNullOrWhiteSpace(textBox_UrunKod.Text) || string.IsNullOrWhiteSpace(textBox_UrunAdi.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Ürün kodunun benzersizliğini kontrol et
                if (KontrolUrun.UrunKod != textBox_UrunKod.Text)
                {
                    bool IsExistUrunKodu = _urunManager.GetAllUrun().Any(x => x.UrunKod == textBox_UrunKod.Text);
                    if (IsExistUrunKodu)
                    {
                        MessageBox.Show("Bu Kod İle Kayıtlı Urun Bulunmaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;// return olmaz ise  alt tarafdaki kodlar  çalışır
                    }
                }
                // Güncelleme işlemi
                KontrolUrun.UrunKod = textBox_UrunKod.Text;
                KontrolUrun.UrunAdi = textBox_UrunAdi.Text.Equals(KontrolUrun.UrunAdi) ? KontrolUrun.UrunAdi : textBox_UrunAdi.Text;
                KontrolUrun.BirimAgirlik = textBox_UrunAgirlik.Text.Equals(KontrolUrun.BirimAgirlik) ? KontrolUrun.BirimAgirlik : textBox_UrunAgirlik.Text;


                //Güncelleme  Bu  sekilde olmaz Lot güncelemesini kontrol et!!!!!
                bool result = _urunManager.UrunGuncelle(KontrolUrun);
                if (result) MessageBox.Show("Ürün başarıyla güncellendi.");
                else MessageBox.Show("Ürün güncelleme işlemi başarısız.");
            }
            else { return; }
            UrunGetir();
        }
        private void button_UrunSoftSil_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No) { return; /* Kullanıcı hayır dedi, işlemi iptal et*/}
            else
            {
                var kontrolUrun = _urunManager.GetUrunById(urunId);
                if (kontrolUrun == null)
                { MessageBox.Show("Silinecek ürün bulunamadı."); return; }
                if (string.IsNullOrWhiteSpace(kontrolUrun.UrunAdi) || string.IsNullOrWhiteSpace(kontrolUrun.UrunKod))
                { MessageBox.Show("Ürün bilgileri eksik, silme işlemi gerçekleştirilemiyor."); return; }
                bool isDelete = _urunManager.UrunSoftSil(urunId);
                if (isDelete) MessageBox.Show("Ürün başarıyla silindi.");
                else MessageBox.Show("Ürün silme işlemi başarısız.");
            }
            UrunGetir();
        }
        private void button_UrunSil_Click(object sender, EventArgs e)
        {
            var KontrolUrun = _urunManager.GetUrunById(urunId);
            if (KontrolUrun == null)
            { MessageBox.Show("Silinecek ürün bulunamadı."); return; }
            DialogResult confirmResult = MessageBox.Show("Ürünü kalıcı olarak silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if ((confirmResult == DialogResult.No)) { return; }
            else
            {
                bool isDelete = _urunManager.UrunKaliciSil(KontrolUrun.ID);
                if (isDelete) MessageBox.Show("Ürün kalıcı olarak başarıyla silindi.");
                else MessageBox.Show("Ürün kalıcı silme işlemi başarısız.");
            }
            UrunGetir();
        }

        #endregion

        #region Lot

        TblLot lot;
        private void LotDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lot = new TblLot();
            lot.ID = Convert.ToInt32(dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["ID"].Value.ToString());
            textBox_LotNo.Text = dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["LotKodu"].Value.ToString();
            comboBox_UrunLot.Text = dataGridView_LotList.Rows[dataGridView_LotList.SelectedCells[0].RowIndex].Cells["UrunAdi"].Value.ToString();
        }

        private void button_LotKayit_Click(object sender, EventArgs e)
        {
            var result = _urunLotMenager.GetUrunByUrunName(comboBox_UrunLot.Text);
            if (result == null)
            {
                MessageBox.Show("Seçilen ürün bulunamadı. Lütfen geçerli bir ürün seçin.");
                return;
            }

            _urunLotMenager.LotKaydet(new TblLot
            {
                LotNo = textBox_LotNo.Text,
                UrunID = result.ID,
                Status = true
            });

            LotUrunGetir();
        }

        private void button_LotGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Ürün bilgilerini güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No) { return; /* Kullanıcı hayır dedi, işlemi iptal et*/}

            var KontrolLot = _urunLotMenager.GetLotById(lot.ID);
            if (KontrolLot == null)
            {
                MessageBox.Show("Güncellenecek lot bulunamadı.");
                return;
            }
            var Urun = _urunLotMenager.GetUrunByUrunName(comboBox_UrunLot.Text);
            if (Urun == null)
            { MessageBox.Show("Seçilen ürün bulunamadı. Lütfen geçerli bir ürün seçin."); return; }
            KontrolLot.LotNo = textBox_LotNo.Text.Equals(KontrolLot.LotNo) ? KontrolLot.LotNo : textBox_LotNo.Text;
            KontrolLot.UrunID = Urun.ID == KontrolLot.ID ? KontrolLot.UrunID : Urun.ID;
            bool İsUpdate = _urunLotMenager.LotGuncelle(KontrolLot);
            DialogResult result = İsUpdate ? MessageBox.Show("Lot başarıyla güncellendi.") : MessageBox.Show("Lot güncelleme işlemi başarısız.");


            LotUrunGetir();

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
            var KontrolLot = _urunLotMenager.GetLotById(lot.ID);
            if (KontrolLot == null)
            {
                MessageBox.Show("Silinecek lot bulunamadı.");
                return;
            }
            else
            {
                DialogResult confirmDelete = MessageBox.Show("Lotu  silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.No)
                {
                    return; // Kullanıcı hayır dedi, işlemi iptal et
                }
                else
                {
                    KontrolLot = _urunLotMenager.GetLotById(lot.ID);
                    KontrolLot.Status = false;
                    bool isDelete = _urunLotMenager.LotGuncelle(KontrolLot);
                }

            }
            LotUrunGetir();

        }

        private void button_LotKaliciSil_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Lotu kalıcı olarak silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return; // Kullanıcı hayır dedi, işlemi iptal et
            }
            var result = _urunLotMenager.GetLotById(lot.ID);
            DialogResult Kontrol = result == null ? MessageBox.Show("Silinecek lot bulunamadı.") : MessageBox.Show("Lot bulunuyor, silme işlemi gerçekleştiriliyor.");
            if (result != null)
            {
                bool isDelete = _urunLotMenager.LotKaliciSil(lot.ID);
                DialogResult finalResult = isDelete ? MessageBox.Show("Lot Kalıcı Silme Başarılı Olmuştur.") : MessageBox.Show("Lot Kalıcı Silme Başarısız Olmuştur.");
            }
            LotUrunGetir();


        }

        #endregion
        public void ClearAllFields()
        {
            // Personel sekmesi
            textBox_AdSoyad.Clear();
            textBox_Sifre.Clear();
            textBox_KullaniciAd.Clear();
            comboBox_RolSecim.SelectedIndex = -1;

            // Ürün sekmesi
            textBox_UrunAdi.Clear();
            textBox_UrunKod.Clear();
            textBox_UrunAgirlik.Clear();

            // Lot sekmesi
            textBox_LotNo.Clear();
            comboBox_UrunLot.SelectedIndex = -1;

        }

        // Personel Rol Listeleme
        public void PersonelRolGetir() => dataGridViewKullanıcıList.DataSource = _personelRolMenager.GetAllPersonelRol();

        // Ürün Lot Listeleme
        public void LotUrunGetir() => dataGridView_LotList.DataSource = _urunLotMenager.GetAllLotUrun().Where(w => w.Status == true).ToList();

        public void UrunGetir() => dataGridView_UrunList.DataSource = _urunLotMenager.GetAllUrun();

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

        private void button_BarkodKontrol_Click(object sender, EventArgs e)
        {
            try
            {
                int UrunId = GetUrunIdByUrunkod(textBox_LotNoRead.Text);
                //var lotk = _urunLotMenager.GetLotById(UrunId);
                if (_urunLotMenager.ExistUrunId(comboBox_LotNoWrite.SelectedItem.ToString(), UrunId))
                {
                    var (result, agirlik) = _uretim.UrunConfirm(comboBox_LotNoWrite.SelectedItem.ToString());
                    label_LotVar.Text = result.Any(x => x.lotNo == textBox_LotNoRead.Text).ToString();
                    label_UrunAd.Text = result.FirstOrDefault(x => x.urunAdi != null).urunAdi;
                    label_UrunKodRead.Text = result.FirstOrDefault(k => k.urunKodu != null).urunKodu;
                    label_Agirlik.Text = _uretim.AgirlikAtama().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UretilenUrunler()
        {
            dataGridView_Uretilen.DataSource = _uretim.GetUretilenUrun(comboBox_LotNoWrite.SelectedItem.ToString()).Any(c => c.LotNo != comboBox_LotNoWrite.SelectedItem.ToString());
            throw new Exception("Bu Lot Kodu İle Üretim Yapılamaz.");
        }
        public void UrunLotNoGetir() => comboBox_LotNoWrite.Items.AddRange(_urunLotMenager.GetAllLotUrun().Where(w => w.Status == true).Select(x => x.LotKodu).ToArray());
        public int GetUrunIdByUrunkod(string urunKod)
        {
            var urun = _urunManager.GetUrunByUrunkod(urunKod);
            if (urun != null) { return urun.ID; }
            return -1;//kayıt yok
        }

        private void button_Kaydet_Click(object sender, EventArgs e)
        {
            TblKoli Koli = new TblKoli();

            if (Koli == null) { MessageBox.Show("Kayıt Bulunamadı"); return; }
            else
            {
                Koli.KoliKodu = _koliManager.GetKoliByLotNo(comboBox_LotNoWrite.SelectedItem.ToString(),null).FirstOrDefault().KoliKodu;
                Koli.UrunId = _koliManager.GetKoliByLotNo(null,textBox_LotNoRead.Text).FirstOrDefault().UrunId;
                Koli.LotId = _koliManager.GetKoliByLotNo(comboBox_LotNoWrite.SelectedItem.ToString(), null).FirstOrDefault().LotId;
                Koli.NetAgirlik = _koliManager.GetKoliByLotNo(comboBox_LotNoWrite.SelectedItem.ToString(), null).FirstOrDefault().NetAgirlik;
                Koli.OlusturmaTarih = _koliManager.GetKoliByLotNo(comboBox_LotNoWrite.SelectedItem.ToString(), null).FirstOrDefault().OlusturmaTarih;

                bool issaved = _koliManager.KoliKayit(Koli);
                KoliGetir();
            }
        }
            public void KoliGetir(){ dataGridView_Uretilen.DataSource = _koliManager.GetAllKoli(); }
        }
    }

