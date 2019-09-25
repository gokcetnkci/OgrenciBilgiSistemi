using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Interface
{
    interface IOgretmen
    {
        List<Ogretmen> OgretmenList(int Id);
        Ogretmen GetOgretmen(int Id);
        Ogretmen_Ogrenci_Ders GetTeacher(int dersId, int type);
    }
}
