using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using DepoYonetim.Core.Enums;
using System.Data;
using DepoYonetim.Application;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace DepoYonetim.Aplication
{
    public class Uretim
    {
        private readonly Repository _repository;

        public Uretim(Repository Repo) => _repository = Repo;

        Random rnd = new Random();
        
        public List<UretilenUrun> GetUretilenUrun(string LotNo)
        {
            var Lotrequest = _repository.GetByData($"SELECT * FROM Tbl_Lot WHERE LotNo = '{LotNo}'");
            if (Lotrequest._state != State.Success) throw new Exception("Üretim verileri alınamadı: " + Lotrequest.message);

            var UrunRequest = _repository.GetByData("SELECT * FROM Tbl_Urun");
            if (UrunRequest._state != State.Success) throw new Exception("Üretim verileri alınamadı: " + UrunRequest.message);

            var query = from lot in Lotrequest.dt.AsEnumerable()
                        join urun in UrunRequest.dt.AsEnumerable()
                        on lot.Field<int>("ID") equals urun.Field<int>("ID")
                        select new UretilenUrun
                        {
                            AktifUrunAd = urun.Field<string>("UrunAdi"),
                            LotNo = lot.Field<string>("LotNo"),
                            Agirlik = rnd.Next(0, 10),
                            Tarih = urun.Field<DateTime>("Tarih"),
                            Status = lot.Field<bool>("Status")
                        };
            return query.ToList();
        }
        


        public List<UretimLotUrun> UrunConfirm(string LotNo)
        {

            var urunRequest = _repository.GetByData("SELECT * FROM Tbl_Urun");
            if (urunRequest._state != State.Success) { return null; throw new Exception("Üretim verileri alınamadı: " + urunRequest.message); }

            if (urunRequest.dt == null) throw new Exception("UrunRequest.dt NULL geldi.");

            LotNo = LotNo.Trim();
            var lotRequest = _repository.GetByData($"SELECT * FROM Tbl_Lot WHERE LotNo='{LotNo}'");
            if (lotRequest._state != State.Success) { return null; throw new Exception("Üretim verileri alınamadı: " + lotRequest.message); }

            if (lotRequest.dt == null) throw new Exception("LotRequest.dt NULL geldi (Repository GetByData DataTable üretmedi).");

            AgirlikAtama();

            var list = from urun in urunRequest.dt.AsEnumerable()
                       join lot in lotRequest.dt.AsEnumerable()
                       on urun.Field<int>("ID") equals lot.Field<int>("UrunID")
                       // Project the result into PersonelRol objects
                       select new UretimLotUrun
                       {
                           lotNo = lot.Field<string>("LotNo"),
                           urunAdi = urun.Field<string>("UrunAdi"),
                           urunKodu = urun.Field<string>("UrunKod"),
                           lotDurumu = lot.Field<bool?>("Status") ?? false
                       };

            return list.ToList() ;

            
        }       
        public int AgirlikAtama() { int sayi = rnd.Next(1, 11); return sayi; }
        
        public bool UrunControl(string ıd)
        {

        }

          


       
    }
}
