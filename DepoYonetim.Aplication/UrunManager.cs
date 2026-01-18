using DepoYonetim.Core.Enums;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Application
{
    public class UrunManager
    {
        readonly Repository _repository;
        public UrunManager(Repository repository) => _repository = repository;

        public List<TblUrun> GetAllUrun()
        {
            var request_Urun = _repository.GetByData("SELECT * FROM Tbl_Urun");
            if (request_Urun._state != State.Success) throw new Exception("Ürün verileri alınamadı: " + request_Urun.message);
            var query = request_Urun.dt.AsEnumerable().Select(s => new TblUrun
            {
                ID = s.Field<int>("ID"),
                UrunKod = s.Field<string>("UrunKod"),
                UrunAdi = s.Field<string>("UrunAdi"),
                BirimAgirlik = s.Field<string>("BirimAgirlik"),
                Status=s.Field<bool>("status")
            });

            return query.ToList();

        }

        public TblUrun GetUrunById(int Id)
        {
            var request = _repository.GetByData($"Select * From Tbl_Urun Where ID='{Id}' ");
            if (request._state != State.Success) throw new Exception("Ürün verisi alınamadı: " + request.message);
            if (request.dt.Rows.Count == 0) return null;
            var query = request.dt.AsEnumerable().Select(s => new TblUrun
            {
                ID = s.Field<int>("ID"),
                UrunKod = s.Field<string>("UrunKod"),
                UrunAdi = s.Field<string>("UrunAdi"),
                BirimAgirlik = s.Field<string>("BirimAgirlik"),
                Status = s.Field<bool>("status")
            }
            );
            return query.FirstOrDefault();
        }

        public bool UrunKaydet(TblUrun dt)
        {
            string insertQuery = $"INSERT INTO Tbl_Urun (UrunKod,UrunAdi,Status) VALUES ('{dt.UrunKod}','{dt.UrunAdi}',{1})";
            #region DiffQuery
            //string diffrentquery = $"IF NOT EXISTS (SELECT 1 FROM Tbl_Urun WHERE UrunKod = '{dt.UrunKod}') BEGIN {insertQuery} END";
            //string insertQuery2 = $"INSERT INTO Tbl_Urun (UrunKod,UrunAdi) SELECT '{dt.UrunKod}','{dt.UrunAdi}' WHERE NOT EXISTS (SELECT 1 FROM Tbl_Urun WHERE UrunKod = '{dt.UrunKod}')";
            #endregion

            var request = _repository.ExecuteSql(insertQuery, null);
            return request._state == State.Success ? true : false; throw new Exception("Urun Kaydedilemedi");
        }

        public bool UrunGuncelle(TblUrun dt)
        {
            string queryUpdate = ($"Update Tbl_Urun set UrunKod='{dt.UrunKod}',UrunAdi='{dt.UrunAdi}' where ID={dt.ID}");
            var request = _repository.ExecuteSql(queryUpdate, null);
            if (request._state != State.Success) return false;
            else return true;
        }

        public bool UrunSoftSil(int id)
        {
            string softDelQuery = ($"Update Tbl_Urun set Status=0 where ID={id}");
            return _repository.ExecuteSql(softDelQuery, null)._state == State.Success ? true : false;
        }

        public bool UrunKaliciSil(int id)
        {
            string delQuery = ($"Delete from Tbl_Urun where ID={id}");
            return _repository.ExecuteSql(delQuery, null)._state == State.Success ? true : false;
        }

        public void UrunAgirlikGüncelleme(int Agirlik)
        {
        }

    }
}
