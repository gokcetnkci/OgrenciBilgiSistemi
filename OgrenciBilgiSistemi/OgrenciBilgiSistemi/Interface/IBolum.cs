using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Interface
{
    interface IBolum
    {
        List<Bolum> DepartmentList();
        List<Bolum> DepartmentList(string fakulte);
        Bolum GetDepartment(int BolumId);
    }
}
