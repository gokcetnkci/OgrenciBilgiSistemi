using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciBilgiSistemi.Model;
using OgrenciBilgiSistemi.Interface;
using System.Data.Entity;

namespace OgrenciBilgiSistemi.DAL
{
    class HelperStudent : IOgrenci
    {
        public Ogrenci GetStudent(int Id)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Ogrenci.Where(x => x.OgrId == Id).FirstOrDefault();
            }
        }

        public List<Ogrenci_Ders_Model> GetLessons(int Id, int type)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                var a = o.Ogretmen_Ogrenci_Ders.Where(x => x.Type == type && x.Ogrt_Ogr_ID == Id).ToList();
                List<Ogrenci_Ders_Model> oml = new List<Ogrenci_Ders_Model>();
                foreach (var item in a)
                {
                    Ogrenci_Ders_Model ogr = new Ogrenci_Ders_Model();
                    ogr.Ders.DersId          = item.Ders.DersId;
                    ogr.Ders.DersKodu        = item.Ders.DersKodu;
                    ogr.Ders.DersAdi         = item.Ders.DersAdi;
                    ogr.Ders.Kredi           = item.Ders.Kredi;
                    ogr.Ogretmen.OgretmenAdi = item.Ogretmen.OgretmenAdi;
                    ogr.Vize1                = item.Vize1;
                    ogr.Vize2                = item.Vize2;
                    ogr.Final                = item.Final;
                    oml.Add(ogr);
                }
                return oml;
            }
        }      

        public List<Ogrenci> GetStudentListByID(int dersID, int type)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                var d = o.Ogretmen_Ogrenci_Ders.Where(x => x.DersID == dersID && x.Type == type).ToList();
                List<Ogrenci> sl = new List<Ogrenci>();
                foreach (var item in d)
                {
                    var s = o.Ogrenci.Where(x => x.OgrId == item.Ogrt_Ogr_ID).FirstOrDefault();
                    sl.Add(s);
                }
                return sl;
            }
        }

        public List<StudentModel> StudentList(int aktifpasif)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                var a = o.Ogrenci.Where(x => x.AktifPasif == aktifpasif).ToList();
                List<StudentModel> st = new List<StudentModel>();
                foreach (var item in a)
                {
                    StudentModel ogr = new StudentModel();
                    ogr.OgrId             = item.OgrId;
                    ogr.OgrNo             = item.OgrNo;
                    ogr.Ad                = item.Ad;
                    ogr.Soyad             = item.Soyad;
                    ogr.Tc                = item.Tc;
                    ogr.DogumTarih        = item.DogumTarih;
                    ogr.Cinsiyet          = item.Cinsiyet;
                    ogr.Email             = item.Email;
                    ogr.Bolum.BolumId     = item.Bolum.BolumId;
                    ogr.Bolum.BolumAdi    = item.Bolum.BolumAdi;
                    ogr.Bolum.FakulteAdi  = item.Bolum.FakulteAdi;
                    ogr.KayityapanID      = item.KayityapanID;
                    ogr.KayitYapilantarih = item.KayitYapilantarih;
                    ogr.AktifPasif        = item.AktifPasif;
                    st.Add(ogr);
                }
                return st;                
            }

        }

        public bool CUD(Ogrenci o, EntityState state)
        {
            using (OBSEntities2 ogr = new OBSEntities2())
            {
                ogr.Entry(o).State = state;
                if (ogr.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        
    }
}
