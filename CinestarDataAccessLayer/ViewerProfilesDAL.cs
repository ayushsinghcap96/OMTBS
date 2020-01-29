using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarDataAccessLayer
{
    public class ViewerProfilesDAL
    {
        public ViewerProfilesDAL()
        {
        }

        public static bool AddViewerProfilesDAL(ViewerProfileEntity newViewerProfile)
        {
            bool viewerProfileAdded = false;
            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var ObjViewerProfile = new ViewerProfile();


                ObjViewerProfile.FirstName = newViewerProfile.FirstName;
                ObjViewerProfile.LastName = newViewerProfile.LastName;
                ObjViewerProfile.MobileNo = newViewerProfile.MobileNo;
                ObjViewerProfile.EmailId = newViewerProfile.EmailId;
                ObjViewerProfile.UserName = newViewerProfile.UserName;

                ObjContext.ViewerProfiles.Add(ObjViewerProfile);
                int NoOfRowsAffected = ObjContext.SaveChanges();
                if (NoOfRowsAffected > 0)
                {
                    newViewerProfile.ViewersId = ObjViewerProfile.ViewersId;
                    viewerProfileAdded = true;
                }
                else
                {
                    viewerProfileAdded = false;
                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions(ex.Message);
            }
            return viewerProfileAdded;
        }

        //public static List<ViewerProfile> GetAllViewerProfilesDAL()
        //{
        //    List<ViewerProfile> ObjViewerProfileList = new List<ViewerProfile>();


        //    try
        //    {
        //        CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
        //        var Query = from ViewerProfile in ObjContext.ViewerProfiles
        //                    select ViewerProfile;
        //        ViewerProfile ObjTempViewerProfile = null;
        //        foreach (var obj in Query)
        //        {
        //            ObjTempViewerProfile = new ViewerProfile();
        //            ObjTempViewerProfile.ViewersId = obj.ViewersId;
        //            ObjTempViewerProfile.FirstName = obj.FirstName;
        //            ObjTempViewerProfile.LastName = obj.LastName;
        //            ObjTempViewerProfile.MobileNo = obj.MobileNo;
        //            ObjTempViewerProfile.EmailId = obj.EmailId;
        //            ObjTempViewerProfile.UserName = obj.UserName;

        //            ObjViewerProfileList.Add(ObjTempViewerProfile);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new MovieExceptions("Error : Reading data", ex);
        //    }

        //    return ObjViewerProfileList;
        //}


        //public static bool UpdateViewerProfileDAL(ViewerProfile updateViewerProfile)
        //{
        //    bool viewerProfileUpdated = false;
        //    try
        //    {
        //        CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
        //        var ObjViewerProfile = ObjContext.ViewerProfiles.Find(updateViewerProfile.ViewersId);
        //        if (ObjViewerProfile != null)
        //        {
        //            ObjViewerProfile.FirstName = updateViewerProfile.FirstName;
        //            ObjViewerProfile.LastName = updateViewerProfile.LastName;
        //            ObjViewerProfile.MobileNo = updateViewerProfile.MobileNo;
        //            ObjViewerProfile.EmailId = updateViewerProfile.EmailId;
        //            ObjViewerProfile.UserName = updateViewerProfile.UserName;


        //            int NoOfRowsAffected = ObjContext.SaveChanges();
        //            viewerProfileUpdated = NoOfRowsAffected > 0;
        //        }
        //        else
        //        {
        //            viewerProfileUpdated = false;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw new MovieExceptions(ex.Message);
        //    }
        //    return viewerProfileUpdated;
        //}
        public static ViewerProfileEntity SearchViewerProfileByUsernameDAL(string id)
        {
            ViewerProfileEntity searchViewerProfile = new ViewerProfileEntity();

            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var query = from item in ObjContext.ViewerProfiles
                            where item.UserName.Equals(id)
                            select item;
                ViewerProfile profile = query.FirstOrDefault();
                int Viewerid = profile.ViewersId;
                var ObjViewerProfile = ObjContext.ViewerProfiles.Find(Viewerid);
                if (ObjViewerProfile != null)
                {
                    searchViewerProfile.ViewersId = ObjViewerProfile.ViewersId;
                    searchViewerProfile.FirstName = ObjViewerProfile.FirstName;
                    searchViewerProfile.LastName = ObjViewerProfile.LastName;
                    searchViewerProfile.MobileNo = ObjViewerProfile.MobileNo;
                    searchViewerProfile.EmailId = ObjViewerProfile.EmailId;
                    searchViewerProfile.UserName = ObjViewerProfile.UserName;
                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading searching data", ex);
            }
            return searchViewerProfile;

        }

        public static ViewerProfileEntity SearchViewerProfileByIdDAL(int id)
        {
            ViewerProfileEntity searchViewerProfile = new ViewerProfileEntity();

            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
               
                var ObjViewerProfile = ObjContext.ViewerProfiles.Find(id);
                if (ObjViewerProfile != null)
                {
                    searchViewerProfile.ViewersId = ObjViewerProfile.ViewersId;
                    searchViewerProfile.FirstName = ObjViewerProfile.FirstName;
                    searchViewerProfile.LastName = ObjViewerProfile.LastName;
                    searchViewerProfile.MobileNo = ObjViewerProfile.MobileNo;
                    searchViewerProfile.EmailId = ObjViewerProfile.EmailId;
                    searchViewerProfile.UserName = ObjViewerProfile.UserName;
                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading searching data", ex);
            }
            return searchViewerProfile;

        }
    }
}
