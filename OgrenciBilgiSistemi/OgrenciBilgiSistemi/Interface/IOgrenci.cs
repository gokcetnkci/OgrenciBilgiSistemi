using OgrenciBilgiSistemi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Interface
{
    interface IOgrenci
    {
        Ogrenci GetStudent(int Id);
        List<Ogrenci_Ders_Model> GetLessons(int Id, int type);
        List<Ogrenci> GetStudentListByID(int dersID, int type);
        List<StudentModel> StudentList(int aktifpasif);
        bool CUD(Ogrenci o, EntityState state);
    }
}
