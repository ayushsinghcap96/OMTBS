using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarDataAccessLayer
{
    public class UserDAL
    {
        public UserDAL()
        {
        }
        public bool LoginUserDAL(UserEntity userlogin)
        {
            CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
            User test = ObjContext.Users.Find(userlogin.UserName);
            if (test != null)
            {
                if (test.UserName.Equals(userlogin.UserName) && test.Password.Equals(userlogin.Password))
                    return true;
                else
                    return false;
            }
            else return false;

        }
        public bool SignUpUserDAL(UserEntity newUser)
        {
            bool userAdded = false;
            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var ObjUser = new User();

                ObjUser.UserName = newUser.UserName;
                ObjUser.Password = newUser.Password;
                ObjContext.Users.Add(ObjUser);
                int NoOfRowsAffected = ObjContext.SaveChanges();
                if (NoOfRowsAffected > 0)
                {
                    newUser.UserName = ObjUser.UserName;
                    userAdded = true;
                }
                else
                {
                    userAdded = false;
                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading data", ex);
            }
            return userAdded;
        }
        public  List<UserEntity> GetAllUsersDAL()
        {
            List<UserEntity> ObjUserList = new List<UserEntity>();


            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var Query = from User in ObjContext.Users
                            select User;
                UserEntity ObjTempUser = null;
                foreach (var obj in Query)
                {
                    ObjTempUser = new UserEntity();

                    ObjTempUser.UserName = obj.UserName;
                    ObjTempUser.Password = obj.Password;

                    ObjUserList.Add(ObjTempUser);
                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading data", ex);
            }

            return ObjUserList;
        }

    }
}
