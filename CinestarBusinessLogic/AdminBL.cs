using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarDataAccessLayer;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarBusinessLogic
{
    public class AdminBL
    {
        private static bool ValidateAdmin(AdminEntity admin)
        {
            StringBuilder sb = new StringBuilder();
            bool validAdmin = true;

            if (admin.AdminName == string.Empty)
            {
                validAdmin = false;
                sb.Append(Environment.NewLine + "Admin Name Required");//it is equivalent to \n , i.e, take the cursor to new line
            }
            if (admin.AdminPassword == string.Empty)
            {
                validAdmin = false;
                sb.Append(Environment.NewLine + "Admin Password Required");//it is equivalent to \n , i.e, take the cursor to new line
            }

            if (validAdmin == false)
                throw new MovieExceptions(sb.ToString());
            return validAdmin;
        }

       

        public static bool AdminLoginBL(AdminEntity adminLogin)
        {
            bool valid = false;
            try
            {
                if (ValidateAdmin(adminLogin))
                {
                    AdminDAL adminDAL = new AdminDAL();
                    valid = adminDAL.AdminLoginDAL(adminLogin);
                }
               
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return valid;
        }
    }
}
