using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Models.Entities
{
    public class UretilenUrun
    {        
        public string AktifUrunAd { get; set; }
        public string LotNo { get; set; }
        public double Agirlik { get; set; }
        public DateTime Tarih { get; set; }
        public bool Status{ get; set; }

    }
}
