

using DepoYonetim.Application;
using DepoYonetim.Core.Enums;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Aplication
{
    public class KoliManager
    {
        private readonly Repository _repository;
        private readonly UrunManager _urunManager;
        private readonly LotUrunMenager _LotUrunMenager;
        private readonly Uretim _Uretim;
        public KoliManager(Repository repository) => _repository = repository;

        public List<TblKoli> GetAllKoli()
        {
            var request = _repository.GetByData("SELECT * FROM Tbl_Koli");
            if ((request.dt == null) || (request._state != State.Success)) throw new Exception("Koli Bulunamadı");

            var query = from koli in request.dt.AsEnumerable()
                        select new TblKoli
                        {
                            Id = koli.Field<int>("Id"),
                            KoliKodu = koli.Field<string>("KoliKodu"),
                            UrunId = koli.Field<string>("UrunId"),
                            LotId = koli.Field<string>("LotId"),
                            NetAgirlik = koli.Field<string>("NetAgirlik"),
                            OlusturmaTarih = koli.Field<DateTime>("OlusturmaTarih")

                        };
            return query.ToList();
        }

        public string GenerateKoliKod() { return "KOL-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(); }

        public List<TblKoli> GetKoli(string LotNo)
        {
            string koliKod = GenerateKoliKod();
            int urunId = _urunManager.GetUrunByUrunkod(LotNo).ID;
            int lotId = _LotUrunMenager.GetIdByLotNo(LotNo);
            string netAgirlik = _Uretim.UrunConfirm(LotNo).Agirlik;
            DateTime Date = DateTime.Now;

            TblKoli lst = new TblKoli
            {
                KoliKodu = GenerateKoliKod(),
                UrunId = _urunManager.GetUrunByUrunkod(LotNo).ID.ToString(),
                LotId = _LotUrunMenager.GetIdByLotNo(LotNo).ToString(),
                NetAgirlik = _Uretim.UrunConfirm(LotNo).Agirlik,
                OlusturmaTarih = DateTime.Now
            };

            return new List<TblKoli> { lst };


        }
        public bool KoliKayit(TblKoli dt)
        {
            string insertQuery = $"INSERT INTO Tbl_Koli (KoliKodu,UrunId,LotId,NetAgirlik,OlusturmaTarih)VALUES('{dt.KoliKodu}','{dt.UrunId}','{dt.LotId}','{dt.NetAgirlik}',{dt.OlusturmaTarih})";

            var request = _repository.ExecuteSql(insertQuery, null);


            return (request._state != State.Success) ? false : true;
        }




    }
}

