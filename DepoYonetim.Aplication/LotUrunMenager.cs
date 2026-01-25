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

namespace DepoYonetim.Application
{
    public class LotUrunMenager
    {
        private readonly Repository _repository;
        public LotUrunMenager(Repository repository) => _repository = repository;

        // LotUrun class contains properties from both Tbl_Lot and Tbl_Urun
        // Example: LotUrun has properties like LotNo, UrunAdi, UrunKod, etc.
        // You need to create LotUrun class in Models/Entities/Urun folder
        public List<LotUrun> GetAllLotUrun()
        {
            // Retrieve lot data
           

            var request_Lot = _repository.GetByData("SELECT * FROM Tbl_Lot");

            // Check if the data retrieval was failed
            if (request_Lot._state != Core.Enums.State.Success) throw new Exception("Lot verileri alınamadı: " + request_Lot.message);

            // Retrieve product data
            var request_Urun = _repository.GetByData("SELECT * FROM Tbl_Urun");
            // Check if the data retrieval was failed
            if (request_Urun._state != Core.Enums.State.Success) throw new Exception("Ürün verileri alınamadı: " + request_Urun.message);


            // Join product and lot data

            var query = from lot in request_Lot.dt.AsEnumerable()
                        join urun in request_Urun.dt.AsEnumerable()
                        on lot.Field<int>("UrunID") equals urun.Field<int>("ID")
                        // Project the result into UrunLot objects
                        select new LotUrun
                        {
                            // Example properties (you need to adjust according to actual properties)
                            ID = lot.Field<int>("ID"),
                            UrunAdi = urun.Field<string>("UrunAdi"),
                            UrunKod = urun.Field<string>("UrunKod"),
                            LotKodu = lot.Field<string>("LotNo"),
                            Status = lot.Field<bool?>("Status") ?? false

                        };





            // Return the result as a list
            return query.ToList();
        }
        //ürün adına göre ürün getir
        public TblUrun GetUrunByUrunName(string urunName)
        {
            try
            {
                var request_Urun = _repository.GetByData($"SELECT * FROM Tbl_Urun WHERE UrunAdi = '{urunName}'");
                if (request_Urun._state != State.Success) throw new Exception("Ürün verileri alınamadı: " + request_Urun.message);
                var UrunRow = request_Urun.dt.AsEnumerable().FirstOrDefault();
                if (UrunRow == null) throw new Exception("Belirtilen Ürün bulunamadı.");
                return new TblUrun
                {
                    ID = UrunRow.Field<int>("ID"),
                    UrunKod = UrunRow.Field<string>("UrunKod"),
                    UrunAdi = UrunRow.Field<string>("UrunAdi")
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        //Tüm ürünleri listele
        public List<TblUrun> GetAllUrun()
        {
            var _request_Urun = _repository.GetByData("SELECT * FROM Tbl_Urun");
            if (_request_Urun._state != State.Success) throw new Exception("Ürün verileri alınamadı: " + _request_Urun.message);
            var urunList = _request_Urun.dt.AsEnumerable().Select(row => new TblUrun
            {
                ID = row.Field<int>("ID"),
                UrunKod = row.Field<string>("UrunKod"),
                UrunAdi = row.Field<string>("UrunAdi"),
                Status = row.Field<bool>("Status")
            });
            return urunList.ToList();
        }

        public TblLot GetLotByID(int ıd)
        {
            var request_Lot = _repository.GetByData($"SELECT * FROM Tbl_Lot WHERE ID = {ıd}");
            if (request_Lot._state != State.Success) throw new Exception("Lot verileri alınamadı: " + request_Lot.message);
            var LotRow = request_Lot.dt.AsEnumerable().FirstOrDefault();
            if (LotRow == null) throw new Exception("Belirtilen Lot bulunamadı.");
            return new TblLot
            {
                ID = LotRow.Field<int>("ID"),
                LotNo = LotRow.Field<string>("LotNo"),
                UrunID = LotRow.Field<int>("UrunID"),
                Status = LotRow.Field<bool>("Status")
            };
        }
        public bool LotKaydet(TblLot lot)
        {
            string insertQuery = $"INSERT INTO Tbl_Lot (LotNo,UrunID,Status) VALUES ('{lot.LotNo}','{lot.UrunID}','{1}')";
            var result = _repository.ExecuteSql(insertQuery, null);
            bool Ret = State.Success == result._state ? true : false;
            return Ret;
        }
        //lot id ye göre lot getir Kontrol Amaclı
        public TblLot GetLotById(int LotId)
        {
            var request_Lot = _repository.GetByData($"SELECT * FROM Tbl_Lot WHERE ID = {LotId}");
            if (request_Lot._state != State.Success) throw new Exception("Lot verileri alınamadı: " + request_Lot.message);

            var LotRow = request_Lot.dt.AsEnumerable().FirstOrDefault();

            if (LotRow == null) throw new Exception("Belirtilen Lot bulunamadı.");
            return new TblLot
            {
                ID = LotRow.Field<int>("ID"),
                LotNo = LotRow.Field<string>("LotNo"),
                UrunID = LotRow.Field<int>("UrunID"),
                Status = LotRow.Field<bool>("Status")
            };
        }

        public bool LotGuncelle(TblLot lot)
        {
            string updateQuery = $"UPDATE Tbl_Lot SET LotNo = '{lot.LotNo}', UrunID = '{lot.UrunID}',Status = '{lot.Status}' WHERE ID = {lot.ID}";
            var result = _repository.ExecuteSql(updateQuery, null);
            if (result._state != State.Success) throw new Exception("lot güncellenemedi: " + result.message);
            else return true;
        }

        public bool LotSoftSil(int LotId)
        {
            string deleteQuery = $"UPDATE Tbl_Lot SET Status = 0 WHERE ID = {LotId}";
            var result = _repository.ExecuteSql(deleteQuery, null);
            if (result._state != State.Success) throw new Exception("Lot silinemedi: " + result.message);
            else return true;
        }

        public bool LotKaliciSil(int lotId)
        {
            string deleteQuery = $"DELETE FROM Tbl_Lot WHERE ID = {lotId}";
            var result = _repository.ExecuteSql(deleteQuery, null);
            if (result._state != State.Success) throw new Exception("Lot silinemedi: " + result.message);
            else return true;
        }
    }
}
