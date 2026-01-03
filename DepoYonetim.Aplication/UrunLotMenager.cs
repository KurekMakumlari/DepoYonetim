using DepoYonetim.DataAccess.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DepoYonetim.Models.Entities;
using DepoYonetim.Models.Entities.Urun;

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
                            // Assuming UrunLotMenager has properties to hold the joined data
                            // Example properties (you need to adjust according to actual properties)
                            UrunID = urun.Field<int>("ID"),
                            UrunAdi = urun.Field<string>("UrunAdi"),
                            LotID = lot.Field<int>("ID"),
                            LotKodu = lot.Field<string>("LotKodu")
                        };
            // Return the result as a list
            return query.ToList();
        }
    }
}
