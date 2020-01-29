using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinestarEntities;
using CinestarBusinessLogic;
using CinestarExceptions;
namespace CinestarMovieBooking.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public ActionResult GetShows(int id)
        {
           
            return View(ShowsBL.GetAllShowsBL(id));
        }

        // GET: Shows/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     
    }
}
