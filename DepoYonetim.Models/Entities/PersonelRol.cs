using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYonetim.Models.Entities
{
    public class PersonelRol
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string SifreHash { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
            
        

    }
}
