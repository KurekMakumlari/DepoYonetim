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
    public partial class PersonelIslem : Form
    {
        public PersonelIslem() => InitializeComponent();

        Repository Repo = new Repository("Data Source=.\\SQLEXPRESS01;Initial Catalog=DepoYonetimi;Integrated Security=True;");

        private void PersonelIslem_Load(object sender, EventArgs e)
        {
            DataGridViewListeleme();
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }        
        private void ComboBoxClick_RolSecim(object sender, EventArgs e)
        {
            var ( dt, state, message) = Repo.GetByData("SELECT * FROM Tbl_Role");
            if (state == State.Success)
            {
                comboBox_RolSecim.DataSource = dt;
                comboBox_RolSecim.DisplayMember = "RoleName";
                comboBox_RolSecim.ValueMember = "Id";
            }
            else MessageBox.Show("Veri çekme işlemi başarısız: " + message);
        }

        private void button_Kayit_Click(object sender, EventArgs e)
        {
            var ( dt , state , message) = Repo.ExecuteSql("INSERT INTO Tbl_Kullanici (AdSoyad,SifreHash,RoleID) VALUES ('" + textBox_AdSoyad.Text + "','" + textBox_Sifre.Text + "'," + comboBox_RolSecim.SelectedValue + ")" , null);

            #region Islemin Basarılı Olma Basarısız Olma Durumu
            if (state == State.Success) MessageBox.Show("Kullanıcı başarıyla eklendi.");
            else MessageBox.Show("Kullanıcı ekleme işlemi başarısız: " + message);
            #endregion

            DataGridViewListeleme();
        }

        public void DataGridViewListeleme()
        {
            var (dt, state, message) = Repo.GetByData("SELECT * FROM Tbl_Kullanici");
            if (state == State.Success)
            {
                dataGridViewKullanıcıList.DataSource = dt;
            }
            else MessageBox.Show("Veri çekme işlemi başarısız: " + message);
        }
    }
}
