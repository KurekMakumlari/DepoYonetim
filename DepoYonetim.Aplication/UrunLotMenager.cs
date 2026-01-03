using DepoYonetim.DataAccess.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DepoYonetim.Models.Entities;
using DepoYonetim.Models.Entities.Urun;
using DepoYonetim.Core.Enums;
using System.Security.Cryptography.X509Certificates;

namespace DepoYonetim.Aplication
{
    public class UrunLotMenager
    {
        private readonly Repository _repository;
        public UrunLotMenager(Repository repository) => _repository = repository;

        public List<UrunLot> GetAllUrunLot()
        {
            // Retrieve product data
            var request_Urun = _repository.GetByData("SELECT * FROM Tbl_Urun");
            // Check if the data retrieval was failed
            if (request_Urun._state != Core.Enums.State.Success) throw new Exception("Ürün verileri alınamadı: " + request_Urun.message);

            // Retrieve lot data
            var request_Lot = _repository.GetByData("SELECT * FROM Tbl_Lot");

            // Check if the data retrieval was failed
            if (request_Lot._state != Core.Enums.State.Success) throw new Exception("Lot verileri alınamadı: " + request_Lot.message);
            // Join product and lot data

            var query = from urun in request_Urun.dt.AsEnumerable()
                        join lot in request_Lot.dt.AsEnumerable()
                        on urun.Field<int>("ID") equals lot.Field<int>("UrunID")
                        // Project the result into UrunLot objects
                        select new UrunLot
                        {
                            // Example properties (you need to adjust according to actual properties)
                            UrunID = urun.Field<int>("ID"),
                            UrunAdi = urun.Field<string>("UrunAdi"),
                            LotID = lot.Field<int>("ID"),
                            LotKodu = lot.Field<string>("LotKodu")
                        };
            // Return the result as a list
            return query.ToList();
        }
        public bool UrunKaydet(TblUrun urun)
        {
            string insertQuery = $"INSERT INTO Tbl_Urun (UrunKod, UrunAdi) VALUES ('{urun.UrunKod}', '{urun.UrunAdi}')";
            var result = _repository.ExecuteSql(insertQuery, null);
            bool Ret = Core.Enums.State.Success == result._state ? true : false;
            return Ret;
        }
        public TblUrun GetUrunById(int urunId)
        {
            var request_Urun = _repository.GetByData($"SELECT * FROM Tbl_Urun WHERE ID = {urunId}");
            if (request_Urun._state != State.Success) throw new Exception("Ürün verileri alınamadı: " + request_Urun.message);

            var urunRow = request_Urun.dt.AsEnumerable().FirstOrDefault();

            if (urunRow == null) throw new Exception("Belirtilen ürün bulunamadı.");
            return new TblUrun
            {
                ID = urunRow.Field<int>("ID"),
                UrunKod = urunRow.Field<string>("UrunKod"),
                UrunAdi = urunRow.Field<string>("UrunAdi")
            };
        }
        public bool UrunGuncelle(TblUrun urun)
        {
            string updateQuery = $"UPDATE TBL_Urun SET (UrunKod = '{urun.UrunKod}', UrunAdi = '{urun.UrunAdi}' WHERE ID = {urun.ID}";
            var result = _repository.ExecuteSql(updateQuery, null);
            if (result._state != State.Success) throw new Exception("Ürün güncellenemedi: " + result.message);
            else return true;
        }

        public bool UrunSoftSil(int urunId)
        {
            string deleteQuery = $"UPDATE Tbl_Urun SET Status = 0 WHERE ID = {urunId}";
            var result = _repository.ExecuteSql(deleteQuery, null);
            if (result._state != State.Success) throw new Exception("Ürün silinemedi: " + result.message);
            else return true;
        }

        public bool KaliciSil(int urunId)
        {
            string deleteQuery = $"DELETE FROM Tbl_Urun WHERE ID = {urunId}";
            var result = _repository.ExecuteSql(deleteQuery, null);
            if (result._state != State.Success) throw new Exception("Ürün silinemedi: " + result.message);
            else return true;
        }
    }
}
