using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Models.Entities
{
    public class UretimLotUrun
    {
       public string lotNo { get; set; } 
       public string urunAdi { get; set; } 
       public string urunKodu { get; set; } 
       public bool lotDurumu { get; set; } 
    }
}
