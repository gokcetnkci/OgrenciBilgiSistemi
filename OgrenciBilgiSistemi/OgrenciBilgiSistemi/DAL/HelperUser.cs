using OgrenciBilgiSistemi.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.DAL
{
    class HelperUser : IUser

    {
        public User GetUser(int Id, int type)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.User.Where(x => x.Ogrt_ogrID == Id && x.Type == type).FirstOrDefault();
            }
        }

        public User StudentUser(string name, string pass)
        {
            using (OBSEntities2 o = new OBSEntities2())
            {
                return o.User.Where(x => x.Username == name && x.Password == pass).FirstOrDefault();
            }
        }

        public bool UserCUD(User u, EntityState state)
        {
            using (OBSEntities2 ogr = new OBSEntities2())
            {
                ogr.Entry(u).State = state;
                if (ogr.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
    }
}
