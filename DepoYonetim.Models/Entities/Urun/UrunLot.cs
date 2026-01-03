using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Models.Entities.Urun
{
    public class UrunLot
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int LotID { get; set; }
        public string LotKodu { get; set; }
    }
}
