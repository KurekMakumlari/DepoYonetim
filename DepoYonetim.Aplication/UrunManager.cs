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
    public  class UrunManager
    {
        readonly Repository _repository;
        public UrunManager(Repository repository)=> _repository = repository;

        public List<TblUrun> GetAllUrun()
        { 
        var request_Urun = _repository.GetByData("SELECT * FROM Tbl_Urun");
            if (request_Urun._state != State.Success) throw new Exception("Ürün verileri alınamadı: " + request_Urun.message);
            var query = request_Urun.dt.AsEnumerable().Select(s=> new TblUrun
                        {
                            ID = s.Field<int>("ID"),
                            UrunKod = s.Field<string>("UrunKod"),
                            UrunAdi = s.Field<string>("UrunAdi")
                        });

            return query.ToList();

        }

        public TblUrun GetUrunById (int Id) 
        {
            var request = _repository.GetByData($"Select * From Tbl_Urun Where ID='{Id}' ");
            if(request._state !=State.Success) throw new Exception("Ürün verisi alınamadı: " + request.message);
            if (request.dt.Rows.Count == 0) return null;
            var query = request.dt.AsEnumerable().Select(s => new TblUrun
            {
                ID = s.Field<int>("ID"),
                UrunKod = s.Field<string>("UrunKod"),
                UrunAdi = s.Field<string>("UrunAdi")
            }
            );
            return query.FirstOrDefault();





        }


    }
}
