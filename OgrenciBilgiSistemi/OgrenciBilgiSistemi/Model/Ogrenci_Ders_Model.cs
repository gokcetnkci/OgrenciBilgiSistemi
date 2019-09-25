using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Model
{
    class Ogrenci_Ders_Model
    {
        public int Ogretmen_Ogrenci_DersID { get; set; }
        public Nullable<int> Ogrt_Ogr_ID { get; set; }
        public Nullable<int> DersID { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Vize1 { get; set; }
        public Nullable<int> Vize2 { get; set; }
        public Nullable<int> Final { get; set; }

        public Ders Ders         = new Ders();
        public Ogrenci Ogrenci   = new Ogrenci();
        public Ogretmen Ogretmen = new Ogretmen();
    }
}
