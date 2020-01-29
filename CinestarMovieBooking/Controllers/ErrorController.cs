using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinestarMovieBooking.Controllers
{
    
        public class ErrorController : Controller
        {
           
            public ActionResult Index(string Message)
            {
                // We choose to use the ViewBag to communicate the error message to the view
                ViewBag.Message = Message;
                return View();
            }

        }
    
}