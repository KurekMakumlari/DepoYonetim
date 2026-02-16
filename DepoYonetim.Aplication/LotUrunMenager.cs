using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using DepoYonetim.Models.Entities.Urun;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepoYonetim.Application
{
    public class LotUrunMenager
    {
        private readonly Repository _repository;
        public LotUrunMenager(Repository repository) => _repository = repository;

        public List<LotUrun> GetAllLotUrun()
        {
            var lotlar = _repository.Query<TblLot>();
            var urunler = _repository.Query<TblUrun>();

            return (from lot in lotlar
                    join urun in urunler on lot.UrunID equals urun.ID
                    select new LotUrun
                    {
                        ID = lot.ID,
                        UrunAdi = urun.UrunAdi,
                        UrunKod = urun.UrunKod,
                        LotKodu = lot.LotNo,
                        Status = lot.Status
                    }).ToList();
        }

        public TblUrun GetUrunByUrunName(string urunName)
        {
            return _repository.Query<TblUrun>().FirstOrDefault(x => x.UrunAdi == urunName);
        }

        public List<TblUrun> GetAllUrun()
        {
            return _repository.Query<TblUrun>().ToList();
        }

        public TblLot GetLotByID(int id)
        {
            return _repository.Query<TblLot>().FirstOrDefault(x => x.ID == id);
        }

        public int GetIdByLotNo(string lotNo)
        {
            var lot = _repository.Query<TblLot>().FirstOrDefault(x => x.LotNo == lotNo && x.Status);
            if (lot == null) throw new Exception("Belirtilen Lot bulunamadı.");
            return lot.ID;
        }

        public bool ExistUrunId(string lotNo, int urunId)
        {
            return _repository.Query<TblLot>().Any(x => x.LotNo == lotNo && x.UrunID == urunId && x.Status);
        }

        public bool LotKaydet(TblLot lot)
        {
            lot.Status = true;
            return _repository.Add(lot).state == Core.Enums.State.Success;
        }

        public TblLot GetLotById(int lotId)
        {
            return _repository.Query<TblLot>().FirstOrDefault(x => x.ID == lotId);
        }

        public bool LotGuncelle(TblLot lot)
        {
            var current = GetLotById(lot.ID);
            if (current == null) return false;

            current.LotNo = lot.LotNo;
            current.UrunID = lot.UrunID;
            current.Status = lot.Status;

            return _repository.Update(current).state == Core.Enums.State.Success;
        }

        public bool LotSoftSil(int lotId)
        {
            var current = GetLotById(lotId);
            if (current == null) return false;

            current.Status = false;
            return _repository.Update(current).state == Core.Enums.State.Success;
        }

        public bool LotKaliciSil(int lotId)
        {
            var current = GetLotById(lotId);
            if (current == null) return false;
            return _repository.Delete(current).state == Core.Enums.State.Success;
        }
    }
}
