using System;
using System.Collections.Generic;
using System.Linq;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;

namespace DepoYonetim.Aplication
{
    public class Uretim
    {
        private readonly Repository _repository;
        private readonly Random _rnd = new Random();

        public Uretim(Repository repo) => _repository = repo;

        public List<UretilenUrun> GetUretilenUrun(string lotNo)
        {
            var lotlar = _repository.Query<TblLot>().Where(x => x.LotNo == lotNo);
            var urunler = _repository.Query<TblUrun>();

            return (from lot in lotlar
                    join urun in urunler on lot.UrunID equals urun.ID
                    select new UretilenUrun
                    {
                        AktifUrunAd = urun.UrunAdi,
                        LotNo = lot.LotNo,
                        Agirlik = _rnd.Next(1, 11),
                        Tarih = DateTime.Now,
                        Status = lot.Status
                    }).ToList();
        }

        public (List<UretimLotUrun>, string Agirlik) UrunConfirm(string lotNo)
        {
            lotNo = (lotNo ?? string.Empty).Trim();

            var lotlar = _repository.Query<TblLot>().Where(x => x.LotNo == lotNo);
            var urunler = _repository.Query<TblUrun>();
            var netAgirlik = AgirlikAtama();

            var list = (from urun in urunler
                        join lot in lotlar on urun.ID equals lot.UrunID
                        select new UretimLotUrun
                        {
                            lotNo = lot.LotNo,
                            urunAdi = urun.UrunAdi,
                            urunKodu = urun.UrunKod,
                            lotDurumu = lot.Status
                        }).ToList();

            return (list, netAgirlik);
        }

        public string AgirlikAtama()
        {
            var sayi = _rnd.Next(1, 11);
            return sayi.ToString();
        }
    }
}
