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
        public Repository(string conString)
        {
            _conString = conString;
        }

        /// <summary>
        /// Verilen SQL sorgusuna göre veritabanından veri çeker ve DataTable olarak döner
        /// </summary>
        /// <param name="sqlQuery">SELECT tipi SQL sorgusu</param>
        /// <returns>DataTable, işlem durumu, mesaj</returns>

        //public (DataTable dt, State _state,string message) GetByData (string sqlQuery)
        //{
        //    try
        //    {
        //        // Gelen veri burada tutulacak
        //        DataTable dt = new DataTable();

        //        // SqlConnection : Veritabanı bağlantısını temsil eder
        //        using (SqlConnection conn = new SqlConnection(_conString)
        //        {

        //            // SqlDataAdapter : SQL sonucunu DataTable'a doldurur

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        
        //}

    }
}
