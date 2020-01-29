using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;

namespace CinestarDataAccessLayer
{
    public class AdminDAL
    {
        public AdminDAL()
        {
        }
       
        public bool AdminLoginDAL(AdminEntity adminLogin)
        {
            CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();

            Admin test = ObjContext.Admins.Find(adminLogin.AdminName);
            if (test != null)
            {
                if (test.AdminName.Equals(adminLogin.AdminName) && test.AdminPassword.Equals(adminLogin.AdminPassword))
                    return true;
                else
                    return false;
            }
            else return false;
        }

    }
}
