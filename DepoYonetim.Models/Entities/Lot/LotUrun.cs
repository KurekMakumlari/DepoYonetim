using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Models.Entities.Urun
{
    public class LotUrun
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; }       
        public string LotKodu { get; set; }
        public string UrunKod { get; set; }
        public bool Status { get; set; }
    }
}
