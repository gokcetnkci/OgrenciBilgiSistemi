using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Interface
{
    interface IUser
    {
        User GetUser(int Id, int type);
        User StudentUser(string name, string pass);
        bool UserCUD(User u, EntityState state);
    }
}
