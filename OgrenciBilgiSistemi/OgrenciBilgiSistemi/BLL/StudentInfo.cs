using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciBilgiSistemi.DAL;
using OgrenciBilgiSistemi.Model;

namespace OgrenciBilgiSistemi.BL
{
    static class StudentInfo
    {
        public static string HarfNotu(double ort)
        {
            
            if (ort >= 0 && ort < 30)
            {
                return "FF";
            }
            else if (ort >= 30 && ort < 60)
            {
                return "DD";
            }
            else if (ort >= 60 && ort < 75)
            {
                return "CC";
            }
            else if (ort >= 75 && ort < 90)
            {
                return "BB";
            }
            else
            {
                return "AA";
            }

        }
    }
    
    public enum Style
    {
        ogretmen = 1,
        ogrenci = 2,
        admin = 3,
    }
}
