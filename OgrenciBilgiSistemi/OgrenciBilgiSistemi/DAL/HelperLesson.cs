using OgrenciBilgiSistemi.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciBilgiSistemi.Model;

namespace OgrenciBilgiSistemi.DAL
{
    class HelperLesson : IDers
    { 
        public List<Ogrenci_Ders_Model> GetLessonList(int type, int aktifpasif)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                var od = o.Ogretmen_Ogrenci_Ders.Where(x => x.Type == type && x.Ders.AktifPasif == aktifpasif).ToList();
                List<Ogrenci_Ders_Model> odml = new List<Ogrenci_Ders_Model>();
                foreach (var item in od)
                {
                    Ogrenci_Ders_Model odm = new Ogrenci_Ders_Model();
                    odm.Ogretmen_Ogrenci_DersID = item.Ogretmen_Ogrenci_DersID;
                    odm.Type                    = item.Type;
                    odm.Vize1                   = item.Vize1;
                    odm.Vize2                   = item.Vize2;
                    odm.Final                   = item.Final;
                    odm.DersID                  = item.DersID;
                    odm.Ders.DersAdi            = item.Ders.DersAdi;
                    odm.Ders.DersKodu           = item.Ders.DersKodu;
                    odm.Ders.Kredi              = item.Ders.Kredi;
                    odm.Ogretmen.OgretmenId     = item.Ogretmen.OgretmenId;
                    odm.Ogretmen.OgretmenAdi    = item.Ogretmen.OgretmenAdi;
                    odm.Ogretmen.BolumId        = item.Ogretmen.BolumId;
                    odm.Ogrt_Ogr_ID             = item.Ogrt_Ogr_ID;
                    odm.Ders.AktifPasif         = item.Ders.AktifPasif;
                    odml.Add(odm);
                }
                return odml;
            }
        }       

        public List<Ogrenci_Ders_Model> GetLessonList(int type, int aktifpasif, int dersID)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                var od = o.Ogretmen_Ogrenci_Ders.Where(x => x.Type == type && x.Ders.AktifPasif == aktifpasif && x.DersID == dersID).ToList();
                List<Ogrenci_Ders_Model> odml = new List<Ogrenci_Ders_Model>();
                foreach (var item in od)
                {
                    Ogrenci_Ders_Model odm = new Ogrenci_Ders_Model();
                    odm.Ogretmen_Ogrenci_DersID = item.Ogretmen_Ogrenci_DersID;
                    odm.Type                 = item.Type;
                    odm.Vize1                = item.Vize1;
                    odm.Vize2                = item.Vize2;
                    odm.Final                = item.Final;
                    odm.DersID               = item.DersID;
                    odm.Ders.DersAdi         = item.Ders.DersAdi;
                    odm.Ders.DersKodu        = item.Ders.DersKodu;
                    odm.Ders.Kredi           = item.Ders.Kredi;
                    odm.Ogretmen.OgretmenAdi = item.Ogretmen.OgretmenAdi;
                    odm.Ogretmen.BolumId     = item.Ogretmen.BolumId;
                    odm.Ogrt_Ogr_ID          = item.Ogrt_Ogr_ID;
                    odm.Ders.AktifPasif      = item.Ders.AktifPasif;
                    odml.Add(odm);
                }
                return odml;
            }
        }

        public List<Ogrenci_Ders_Model> OgrGetLessonList(int type, int aktifpasif, int bolumId)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                var od = o.Ogretmen_Ogrenci_Ders.Where(x => x.Type == type && x.Ders.AktifPasif == aktifpasif && x.Ders.BolumId == bolumId).ToList();
                List<Ogrenci_Ders_Model> odml = new List<Ogrenci_Ders_Model>();
                foreach (var item in od)
                {
                    Ogrenci_Ders_Model odm = new Ogrenci_Ders_Model();
                    odm.Ogretmen_Ogrenci_DersID = item.Ogretmen_Ogrenci_DersID;
                    odm.Type                 = item.Type;
                    odm.Vize1                = item.Vize1;
                    odm.Vize2                = item.Vize2;
                    odm.Final                = item.Final;
                    odm.DersID               = item.DersID;
                    odm.Ders.DersAdi         = item.Ders.DersAdi;
                    odm.Ders.DersKodu        = item.Ders.DersKodu;
                    odm.Ders.Kredi           = item.Ders.Kredi;
                    odm.Ders.BolumId         = item.Ders.BolumId;
                    odm.Ogretmen.OgretmenAdi = item.Ogretmen.OgretmenAdi;
                    odm.Ogretmen.BolumId     = item.Ogretmen.BolumId;
                    odm.Ogrt_Ogr_ID          = item.Ogrt_Ogr_ID;
                    odm.Ders.AktifPasif      = item.Ders.AktifPasif;
                    odml.Add(odm);
                }
                return odml;
            }
        }

        public Ogretmen_Ogrenci_Ders GetLesson(int Id)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Ogretmen_Ogrenci_Ders.Where(x => x.Ogretmen_Ogrenci_DersID == Id).FirstOrDefault();
            }
        }
        
        public List<Ders> GetLessonById(int Id)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Ders.Where(x => x.BolumId == Id).ToList();
            }
        }

        public Ders GetLessonBydersId(int dersId)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Ders.Where(x => x.DersId == dersId).FirstOrDefault();
            }
        }

        public bool OgretmenDersCUD(Ogretmen_Ogrenci_Ders od, EntityState state)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                o.Entry(od).State = state;
                if (o.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public bool DersCUD(Ders d, EntityState state)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                o.Entry(d).State = state;
                if (o.SaveChanges() > 0)
                    return true;
                return false;                         
            }
        }
    }
}
