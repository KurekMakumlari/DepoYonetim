using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using DepoYonetim.Core.Enums;
using System.Data;

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
            if (Lotrequest._state != State.Success)throw new Exception("Üretim verileri alınamadı: " + Lotrequest.message);

            var UrunRequest = _repository.GetByData("SELECT * FROM Tbl_Urun");
            if (UrunRequest._state != State.Success) throw new Exception("Üretim verileri alınamadı: " + UrunRequest.message);

            var query = from lot in Lotrequest.dt.AsEnumerable()
                        join urun in UrunRequest.dt.AsEnumerable()
                        on lot.Field<int>("ID") equals urun.Field<int>("ID")
                        select new UretilenUrun
                        {
                            AktifUrunAd = urun.Field<string>("UrunAdi"),
                            LotNo = lot.Field<string>("LotNo"),
                            Agirlik = rnd.Next(0,10),
                            Tarih = urun.Field<DateTime>("Tarih"),
                            Status = lot.Field<bool>("Status")
                        };
            return query.ToList();



        }





    }
}
