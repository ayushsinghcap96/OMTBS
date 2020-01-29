using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinestarMovieBooking.Controllers
{
    public class LogInStartController : Controller
    {
        // GET: LogInStart
        public ActionResult SelectLogin()
        {
            Session.Abandon();
            return View();
        }
    }
}