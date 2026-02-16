using DepoYonetim.Application;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepoYonetim.Aplication
{
    public class KoliManager
    {
        private readonly Repository _repository;
        private readonly UrunManager _urunManager;
        private readonly LotUrunMenager _lotUrunMenager;
        private readonly Uretim _uretim;

        public KoliManager(Repository repository)
        {
            _repository = repository;
            _urunManager = new UrunManager(repository);
            _lotUrunMenager = new LotUrunMenager(repository);
            _uretim = new Uretim(repository);
        }

        public List<TblKoli> GetAllKoli()
        {
            return _repository.Query<TblKoli>().ToList();
        }

        public string GenerateKoliKod()
        {
            return "KOL-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        public List<TblKoli> GetKoliByLotNo(string lotNo, string urunKod)
        {
            var urunId = 0;
            if (!string.IsNullOrWhiteSpace(urunKod))
            {
                var urun = _urunManager.GetUrunByUrunkod(urunKod);
                if (urun == null)
                {
                    throw new InvalidOperationException($"Geçersiz ürün kodu: {urunKod}");
                }

                urunId = urun.ID;
            }

            if (urunId == 0 && !string.IsNullOrWhiteSpace(lotNo))
            {
                urunId = _repository.Query<TblLot>()
                    .Where(x => x.LotNo == lotNo)
                    .Select(x => x.UrunID)
                    .FirstOrDefault();
            }

            var lotId = !string.IsNullOrWhiteSpace(lotNo)
                ? _lotUrunMenager.GetIdByLotNo(lotNo)
                : _repository.Query<TblLot>().Where(x => x.UrunID == urunId && x.Status).Select(x => x.ID).FirstOrDefault();

            if (urunId <= 0 || lotId <= 0)
            {
                throw new InvalidOperationException("Koli oluşturmak için geçerli ürün ve lot bilgisi gereklidir.");
            }

            var netAgirlik = !string.IsNullOrWhiteSpace(lotNo)
                ? _uretim.UrunConfirm(lotNo).Agirlik
                : _uretim.AgirlikAtama();

            var koli = new TblKoli
            {
                KoliKodu = GenerateKoliKod(),
                UrunId = urunId.ToString(),
                LotId = lotId.ToString(),
                NetAgirlik = netAgirlik,
                OlusturmaTarih = DateTime.Now
            };

            return new List<TblKoli> { koli };
        }

        public bool KoliKayit(TblKoli koli)
        {
            return _repository.Add(koli).state == Core.Enums.State.Success;
        }
    }
}
