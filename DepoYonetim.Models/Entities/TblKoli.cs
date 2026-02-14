using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Models.Entities
{
    public class TblKoli
    {
        public int Id { get; set; }
        public string KoliKodu { get; set; }
        public string UrunId { get; set; }
        public string LotId { get; set; }
        public string NetAgirlik { get; set; }
        public DateTime OlusturmaTarih { get; set; } 
    }
}
