using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Model
{
    class StudentModel
    {
        public int OgrId { get; set; }
        public Nullable<int> OgrNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tc { get; set; }
        public Nullable<int> BolumId { get; set; }
        public Nullable<int> KayityapanID { get; set; }
        public Nullable<DateTime> KayitYapilantarih { get; set; }
        public Nullable<DateTime> DogumTarih { get; set; }
        public Nullable<short> Cinsiyet { get; set; }
        public Nullable<short> AktifPasif { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Ogretmen_Ogrenci_Ders> Ogretmen_Ogrenci_Ders { get; set; }

        public Bolum Bolum       = new Bolum();
        public Ogretmen Ogretmen = new Ogretmen();
        public User user = new User();
    }
}
