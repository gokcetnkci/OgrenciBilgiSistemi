using OgrenciBilgiSistemi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Interface
{
    interface IDers
    {
        bool DersCUD(Ders d, EntityState state);
        Ogretmen_Ogrenci_Ders GetLesson(int Id);
        List<Ogrenci_Ders_Model> OgrGetLessonList(int type, int aktifpasif, int bolumId);
        List<Ogrenci_Ders_Model> GetLessonList(int type, int aktifpasif, int dersID);
        List<Ogrenci_Ders_Model> GetLessonList(int type, int aktifpasif);
        List<Ders> GetLessonById(int Id);
        Ders GetLessonBydersId(int dersId);
        bool OgretmenDersCUD(Ogretmen_Ogrenci_Ders od, EntityState state);
    }
}
