using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepoYonetim.Application
{
    public class UrunManager
    {
        readonly Repository _repository;
        public UrunManager(Repository repository) => _repository = repository;

        public List<TblUrun> GetAllUrun()
        {
            return _repository.Query<TblUrun>().ToList();
        }

        public TblUrun GetUrunById(int id)
        {
            return _repository.Query<TblUrun>().FirstOrDefault(x => x.ID == id);
        }

        public TblUrun GetUrunByUrunkod(string urunKod)
        {
            var kod = (urunKod ?? string.Empty).Trim();
            return _repository.Query<TblUrun>().FirstOrDefault(x => x.UrunKod.Trim() == kod);
        }

        public bool UrunKaydet(TblUrun urun)
        {
            urun.Status = true;
            return _repository.Add(urun).state == Core.Enums.State.Success;
        }

        public bool UrunGuncelle(TblUrun urun)
        {
            var current = GetUrunById(urun.ID);
            if (current == null)
            {
                return false;
            }

            current.UrunKod = urun.UrunKod;
            current.UrunAdi = urun.UrunAdi;
            current.BirimAgirlik = urun.BirimAgirlik;
            current.Status = urun.Status;

            return _repository.Update(current).state == Core.Enums.State.Success;
        }

        public bool UrunSoftSil(int id)
        {
            var current = GetUrunById(id);
            if (current == null)
            {
                return false;
            }

            current.Status = false;
            return _repository.Update(current).state == Core.Enums.State.Success;
        }

        public bool UrunKaliciSil(int id)
        {
            var current = GetUrunById(id);
            if (current == null)
            {
                return false;
            }

            return _repository.Delete(current).state == Core.Enums.State.Success;
        }
    }
}
