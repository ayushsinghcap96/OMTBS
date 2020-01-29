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
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult ListAllUsers()
        {
            List<UserEntity> listUser = UserBL.GetAllUsersBL();
            return View(listUser);
        }

        //get
        public ActionResult SignUp()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserEntity objNewUsers)
        {
            var IsAdded = UserBL.SignUPUserBL(objNewUsers);
            if (IsAdded)
            {
                string url = string.Format("/ViewerProfiles/CreateProfile?username={0}", objNewUsers.UserName);
                return Redirect(url);
            }

            else
                return View(objNewUsers);
        }

        //get
        public ActionResult LogIn()///////////////////////
        {
            Session.Abandon();
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserEntity userLogin)///////////////////////
        {
            var isLoggedIn = UserBL.LogInBL(userLogin);
            if (isLoggedIn)
            {
                int viewerID = ViewrProfilesBL.SearchViewerProfileByUsernameBL(userLogin.UserName).ViewersId;

                string url = string.Format("/Movies/ListAllMovies?username={0}", userLogin.UserName);
                Session["Username"] = userLogin.UserName;
                Session["ViewerId"] = viewerID;

                return Redirect(url);
            }

            else
            {
                ViewBag.InvalidCredentials = "Invalid Credentials";
                return View(userLogin);

            }


        }

    }
}