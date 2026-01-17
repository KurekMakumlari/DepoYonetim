using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepoYonetim.Core.Enums;
using System.Data.SqlClient;

namespace DepoYonetim.DataAccess.Repostories
{
    public class Repository
    {// Veritabanı bağlantı cümlesini tutan değişken
        private readonly string _conString;

        // Constructor - Repository sınıfı oluşturulduğunda bağlantı cümlesi atanır
        public Repository(string conString) => _conString = conString;


        /// <summary>
        /// Verilen SQL sorgusuna göre veritabanından veri çeker ve DataTable olarak döner
        /// </summary>
        /// <param name="sqlQuery">SELECT tipi SQL sorgusu</param>
        /// <returns>DataTable, işlem durumu, mesaj</returns>
        public (DataTable dt, State _state, string message) GetByData(string sqlQuery)
        {
            try
            {
                // Gelen veri burada tutulacak
                DataTable dt = new DataTable();

                // SqlConnection : Veritabanı bağlantısını temsil eder
                using (SqlConnection conn = new SqlConnection(_conString))
                {
                    // SqlCommand : Çalıştırılacak SQL komutunu ve bağlantıyı tutar
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        // SqlDataAdapter : SQL sonucunu DataTable'a doldurur
                        SqlDataAdapter da = new SqlDataAdapter(command);

                        // Bağlantıyı açmaya gerek yok. SqlDataAdapter Fill sırasında açıp kapatır
                        da.Fill(dt);
                    }
                }

                // Veri başarılı çekildiyse durumu Success olarak döner
                return (dt, State.Success, "Success");
            }
            catch (Exception ex)
            {
                // Hata alındığında boş tablo döner ve hata mesajını iletir
                return (new DataTable(), State.Fail, ex.Message);
            }
        }

        /// <summary>
        /// Verilen tablo adı ve Id değerine göre tek bir kayıt döner
        /// </summary>
        /// <param name="tableName">Sorgulanacak tablo adı</param>
        /// <param name="id">Filtrelenecek Id bilgisi</param>
        /// <returns>DataRow, işlem durumu, mesaj</returns>
        public (DataRow row, State _state, string messge) GetById(string tableName, int id)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(_conString))
                {
                    // Parametreli SQL komutu oluşturuldu (SQL Injection riskini azaltır)
                    string query = $"SELECT * FROM {tableName} WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parametre değeri atanıyor
                        cmd.Parameters.AddWithValue("@Id", id);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                // Eğer veri bulunduysa ilk satır döndürülür
                if (dt.Rows.Count > 0)
                    return (dt.Rows[0], State.Success, "Success");

                // Hiç kayıt bulunmadıysa NotFound döner
                return (null, State.NotFound, "Not Found");
            }
            catch (Exception ex)
            {
                // Hata olduğunda Fail döner
                return (null, State.Fail, ex.Message);
            }
        }
        /// <summary>
        /// Insert, Update veya Delete gibi etkilenecek satır döndüren SQL komutlarını çalıştırır
        /// </summary>
        /// <param name="sqlQuery">İşlem yapılacak SQL komutu</param>
        /// <param name="parameters">Komutta kullanılacak parametreler</param>
        /// <returns>Başarılı mı?, işlem durumu, mesaj</returns>
        public (bool success, State _state, string message) ExecuteSql(string sqlQuery, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conString))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    // Eğer parametre varsa komuta ekleniyor
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    // Komut çalıştırılmadan önce bağlantı açılması gerekir
                    conn.Open();

                    // ExecuteNonQuery : Etkilenen satır sayısını döndürür
                    int result = cmd.ExecuteNonQuery();

                    // İşlem sonucu kontrol edilir
                    if (result > 0)
                        return (true, State.Success, "Success");
                    else
                        return (false, State.NoRowsAffected, "No rows affected");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda Fail döner ve hata mesajı iletilir
                return (false, State.Fail, "Error: " + ex.Message);
            }
        }



    }
}
