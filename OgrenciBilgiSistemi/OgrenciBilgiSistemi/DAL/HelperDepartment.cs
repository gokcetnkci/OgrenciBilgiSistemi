using OgrenciBilgiSistemi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.DAL
{
    class HelperDepartment : IBolum
    {
        public List<Bolum> DepartmentList()
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Bolum.ToList();
            }
        }
        public List<Bolum> DepartmentList(string fakulte)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Bolum.Where(x => x.FakulteAdi == fakulte).ToList();
            }
        }
        public Bolum GetDepartment(int BolumId)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.Bolum.Where(x => x.BolumId == BolumId).FirstOrDefault();
            }
        }
        
    }
}
