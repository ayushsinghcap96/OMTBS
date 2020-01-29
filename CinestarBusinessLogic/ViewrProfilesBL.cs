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
   public class ViewrProfilesBL
    {
        private static bool ValidateViewerProfile(ViewerProfileEntity viewerProfile)
        {
            StringBuilder sb = new StringBuilder();
            bool validViewerProfile = true;
            //if(guest.GuestID <= 0)
            //{
            //    validGuest = false;
            //    sb.Append(Environment.NewLine + "Invalid Guest ID");
            //}
            if (viewerProfile.FirstName == string.Empty)
            {
                validViewerProfile = false;
                sb.Append(Environment.NewLine + "User Name Required");//it is equivalent to \n , i.e, take the cursor to new line
            }
            if (viewerProfile.LastName == string.Empty)
            {
                validViewerProfile = false;
                sb.Append(Environment.NewLine + "User LastName Required");//it is equivalent to \n , i.e, take the cursor to new line
            }
            if (viewerProfile.EmailId == string.Empty)
            {
                validViewerProfile = false;
                sb.Append(Environment.NewLine + "User EmailId Required");//it is equivalent to \n , i.e, take the cursor to new line
            }
            if (viewerProfile.MobileNo == string.Empty)
            {
                validViewerProfile = false;
                sb.Append(Environment.NewLine + "User MobileNo Required");//it is equivalent to \n , i.e, take the cursor to new line
            }

            if (validViewerProfile == false)
                throw new MovieExceptions(sb.ToString());
            return validViewerProfile;
        }

        public static bool AddViewerProfileBL(ViewerProfileEntity newViewerProfile)
        {
            bool viewerProfileAdded = false;
            try
            {
                if (ValidateViewerProfile(newViewerProfile))
                {
                    viewerProfileAdded = ViewerProfilesDAL.AddViewerProfilesDAL(newViewerProfile);
                }
            }
            catch (MovieExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewerProfileAdded;
        }

        //public static List<ViewerProfile> GetAllViewerProfilesBL()
        //{
        //    List<ViewerProfile> viewerProfileList = null;
        //    try
        //    {
        //        viewerProfileList = ViewerProfilesDAL.GetAllViewerProfilesDAL();
        //    }
        //    catch (MovieExceptions ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return viewerProfileList;
        //}



        //public static bool UpdateViewerProfileBL(ViewerProfile updateViewerProfile)
        //{
        //    bool viewerProfileUpdated = false;
        //    try
        //    {
        //        if (ValidateViewerProfile(updateViewerProfile))
        //        {
        //            viewerProfileUpdated = ViewerProfilesDAL.UpdateViewerProfileDAL(updateViewerProfile);
        //        }
        //    }
        //    catch (MovieExceptions)
        //    {
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return viewerProfileUpdated;

        //}
        public static ViewerProfileEntity SearchViewerProfileByUsernameBL(string searchViewerusername)
        {
            ViewerProfileEntity searchViewerProfile = null;
            try
            {
                
                searchViewerProfile = ViewerProfilesDAL.SearchViewerProfileByUsernameDAL(searchViewerusername);
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchViewerProfile;
        }
        public static ViewerProfileEntity SearchViewerProfileByIdBL(int viewerId)
        {
            ViewerProfileEntity searchViewerProfile = null;
            try
            {

                searchViewerProfile = ViewerProfilesDAL.SearchViewerProfileByIdDAL(viewerId);
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchViewerProfile;
        }

    }
}
