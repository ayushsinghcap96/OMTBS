using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinestarEntities;
using CinestarExceptions;
using CinestarBusinessLogic;

namespace CinestarMovieBooking.Controllers
{
    public class ViewerProfilesController : Controller
    {
       
        public ActionResult CreateProfile()
        {
            string username = Request.QueryString["username"];
            ViewBag.username = username;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProfile(ViewerProfileEntity objNewViewerProfiles)
        {
            objNewViewerProfiles.UserName = Request.QueryString["username"];
            var IsAdded =ViewrProfilesBL.AddViewerProfileBL(objNewViewerProfiles);
            if (IsAdded)
            {
                string url = string.Format("/ViewerProfiles/ProfileDetails?username={0}", Request.QueryString["username"]);
                return Redirect(url);
            }

            else
                return View(objNewViewerProfiles);
        }


        //public ActionResult EditProfile(string username)
        //{
        //    var objSearchViewerProfile = ViewerProfilesDAL.Up(username);
        //    return View(objSearchViewerProfile);
        //}
        //[HttpPost]
        //public ActionResult EditProfile(int Viewersid, ViewerProfile objViewerProfileUpdate)
        //{
        //    var IsUpdated = ViewerProfilesDAL.UpdateViewerProfileBL(objViewerProfileUpdate);
        //    if (IsUpdated)
        //        return RedirectToAction("Index");
        //    else
        //        return View(objViewerProfileUpdate);
        //}


        public ActionResult ProfileDetails(string id)///////////////////////
        {
            if (id == null)
            {
                 id = Request.QueryString["username"];
            }
            var objSearchViewerProfile = ViewrProfilesBL.SearchViewerProfileByUsernameBL(id);////////////////////
            return View(objSearchViewerProfile);
        }
    }
}