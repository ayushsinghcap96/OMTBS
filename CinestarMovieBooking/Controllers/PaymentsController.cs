using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinestarExceptions;
using CinestarEntities;
using CinestarBusinessLogic;
namespace CinestarMovieBooking.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: Payments
        public ActionResult CompletePayment()
        {
            return View();
        }
        
        public ActionResult SuccessfulPayment()
        {

            return View();
        }
        //get
        public ActionResult GiveFeedback()
        {
            FeedbackEntity feedback = new FeedbackEntity();
            if (Session["ViewerId"] != null)
            {
                feedback.ViewersId = Convert.ToInt32(Session["ViewerId"].ToString());
                return View(feedback);

            }
            else
            {
                string url = string.Format("/Users/LogIn");
                return Redirect(url);
            }
            //change here


        }

        //post
        [HttpPost]
        public ActionResult GiveFeedback (FeedbackEntity feedback)
        {
            bool isAdded = FeedbackBL.GiveFeedbackBL(feedback);
            if (isAdded)
            {
                string url = string.Format("/Movies/ListAllMovies");
                return Redirect(url);
            }
            else
                return View(feedback);
        }


    }
}