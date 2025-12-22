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

namespace DepoYonetim
{
    public partial class PersonelGirisForm : Form
    {
        SqlConnection Connection = new SqlConnection("Data Source=.;Initial Catalog=DepoYonetim;Integrated Security=True");
        public PersonelGirisForm() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e) { }     

        private void button_Giris_Click(object sender, EventArgs e)
        {
            Connection.Open();
            string Query = "SELECT * FROM Tbl_Personel WHERE ID=@TCNo AND Sifre=@Sifre";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TCNo", maskedTextBox_PerTc.Text);    
            Command.Parameters.AddWithValue("@Sifre", textBox_PerSifre.Text);
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {                    
                    Transfer.PersonelId = Reader["ID"].ToString();
                    Transfer.PersonelAd = Reader.GetString(1); // Assuming Ad is the second column
                    Transfer.PersonelSoyad = Reader.GetString(2); // Assuming Soyad is the third column

                    PersonelAnaForm personelAnaForm = new PersonelAnaForm();
                    personelAnaForm.Show();
                    this.Hide();
                }
            }
            else MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void linkLabel_PerKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
