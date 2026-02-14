

using DepoYonetim.Application;
using DepoYonetim.Core.Enums;
using DepoYonetim.DataAccess.Repostories;
using DepoYonetim.Models.Entities;
using System;
using System.Collections.Generic;
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








        //public string GenerateKoliKod() { return "KOL-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(); }

        //public List<TblKoli> GetKoli(string LotNo)
        //{
        //    int id = _urunManager.GetUrunByUrunkod(LotNo).ID;
        //    int lotId = _LotUrunMenager.GetIdByLotNo(LotNo);
        //    string netAgirlik = _Uretim.UrunConfirm(LotNo).Agirlik;
        //    DateTime Date = DateTime.Now;

        //    var List = new TblKoli { }



        //}


        public bool KoliKayit(TblKoli dt)
        {
            string insertQuery = $"INSERT INTO Tbl_Koli (KoliKodu,UrunId,LotId,NetAgirlik,OlusturmaTarih)VALUES('{dt.KoliKodu}','{dt.UrunId}','{dt.LotId}','{dt.NetAgirlik}',{dt.OlusturmaTarih})";

            var request = _repository.ExecuteSql(insertQuery, null);
            

            return (request._state != State.Success) ? false : true; 
        }




    }
}

