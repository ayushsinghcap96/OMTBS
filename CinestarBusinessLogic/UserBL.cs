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
    public class UserBL
    {
        private static bool ValidateUser(UserEntity user)
        {
            StringBuilder sb = new StringBuilder();
            bool validUser = true;

            if (user.UserName == string.Empty)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "User Name Required");//it is equivalent to \n , i.e, take the cursor to new line
            }
            if (user.Password == string.Empty)
            {
                validUser = false;
                sb.Append(Environment.NewLine + "User Password Required");//it is equivalent to \n , i.e, take the cursor to new line
            }

            if (validUser == false)
                throw new MovieExceptions(sb.ToString());
            return validUser;
        }
        public static bool LogInBL(UserEntity user)
        {
            bool userLoggedIn = false;
            if (ValidateUser(user))
            {
                UserDAL userDAL = new UserDAL();

                userLoggedIn = userDAL.LoginUserDAL(user);
            }
            return userLoggedIn;
        }

        public static bool SignUPUserBL(UserEntity newUser)
        {
            bool userAdded = false;
            try
            {
                if (ValidateUser(newUser))
                {
                    UserDAL userDAL = new UserDAL();
                    userAdded = userDAL.SignUpUserDAL(newUser);
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
            return userAdded;
        }

        public static List<UserEntity> GetAllUsersBL()
        {
            List<UserEntity> userList = null;
            try
            {
                UserDAL userDAL = new UserDAL();
                userList = userDAL.GetAllUsersDAL();
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userList;
        }
    }
}
