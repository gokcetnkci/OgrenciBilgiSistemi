using OgrenciBilgiSistemi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.DAL
{
    class HelperOgretmen : IOgretmen
    {
        public List<Ogretmen> OgretmenList(int Id)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Ogretmen.Where(x => x.BolumId == Id).ToList();
            }
        }

        public Ogretmen GetOgretmen(int Id)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Ogretmen.Where(x => x.OgretmenId == Id).FirstOrDefault();
            }
        }

        public Ogretmen_Ogrenci_Ders GetTeacher(int dersId, int type)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Ogretmen_Ogrenci_Ders.Where(x => x.DersID == dersId && x.Type == type).FirstOrDefault();
            }
        }
    }
}
