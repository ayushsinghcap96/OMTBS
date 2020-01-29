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
    public class AdminsController : Controller
    {
        public ActionResult AdminHome()
        {
            string AdminName = Request.QueryString["AdminName"];

           // return View();
            if (Session["AdminName"]!=null)
            {
                return View();

            }
            else
            {
                string url = string.Format("/Admins/AdminLogIn");
                return Redirect(url);
            }
        }

        public ActionResult AdminLogIn()
        {
            Session.Abandon();

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogIn( AdminEntity objNewAdmins)
        {
            var IsAdded = AdminBL.AdminLoginBL(objNewAdmins);
            if (IsAdded)
            {
                Session["AdminName"] = objNewAdmins.AdminName;
                string url = string.Format("/Admins/AdminHome?AdminName={0}", objNewAdmins.AdminName);
                return Redirect(url);
            }

            else
            {
                ViewBag.InvalidCredentials = "Invalid Credentials";
                return View(objNewAdmins);
            }
                
        }

        // GET: Shows/Create
        public ActionResult CreateShow(int id)
        {
            ShowEntity show = new ShowEntity();
            show.MovieId = id;
            List<SelectListItem> screenList = ScreenBL.ViewAllScreenBL().Select(n => new SelectListItem { Value = n.ScreenId.ToString(), Text = n.ScreenName }).ToList(); ;

            var genreTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select screen ---"
            };
            screenList.Insert(0, genreTip);
            ViewBag.screenList = new SelectList(screenList, "Value", "Text");
            return View(show);
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShow(ShowEntity show)
        {
            bool isAdded = false;
            List<SelectListItem> screenList = ScreenBL.ViewAllScreenBL().Select(n => new SelectListItem { Value = n.ScreenId.ToString(), Text = n.ScreenName }).ToList(); ;

            var genreTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select screen ---"
            };
            screenList.Insert(0, genreTip);
            ViewBag.screenList = new SelectList(screenList, "Value", "Text");
            if (ModelState.IsValid)
            {
                isAdded = ShowsBL.AddShowBL(show);
                if (isAdded)
                    return RedirectToAction("IndexShowAdmin");
            }


            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult EditShow(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ShowEntity show = ShowsBL.SearchShowByIdBL(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditShow(ShowEntity show)
        {
            bool isUpdated = false;
            if (ModelState.IsValid)
            {
                isUpdated = ShowsBL.UpdateShowBL(show);
                if (isUpdated)
                {
                    return RedirectToAction("Index/1");
                }
            }

            return View(show);
        }
        // GET: Shows/Delete/5
        public ActionResult DeleteShow(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ShowEntity show = ShowsBL.SearchShowByIdBL(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        public ActionResult DetailsShow(int id)
        {

            ShowEntity show = ShowsBL.SearchShowByIdBL(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("DeleteShow")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShowConfirmed(int id)
        {
            bool isDeleted = false;
            isDeleted = ShowsBL.DeleteShowBL(id);
            if (isDeleted)
                return RedirectToAction("Index/1");
            return HttpNotFound();
        }



        // GET: Shows
        public ActionResult IndexShowAdmin()
        {

            return View(ShowsBL.GetAllShowsAdminBL());
        }




        //below are movie mehtods
        public ActionResult Index()
        {
            List<MovyEntityNew> listMovie = MovieBL.GetAllMoviesBL();
            return View(listMovie);
        }


        public ActionResult AddMovie()
        {
            List<SelectListItem> genreList = GenreBL.ViewAllGenreBL().Select(n => new SelectListItem{ Value = n.GenreId.ToString(),Text = n.GenreName}).ToList(); ;
                 
            var genreTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select genre ---"
            };
            genreList.Insert(0, genreTip);
            ViewBag.generList = new SelectList(genreList, "Value", "Text");

            List<SelectListItem> languageList = LanguageBL.ViewAllLanguageBL().Select(n => new SelectListItem { Value = n.LanguageId.ToString(), Text = n.LanguageName }).ToList(); ;

            var languageTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select  Language ---"
            };
            languageList.Insert(0, languageTip);
            ViewBag.langList = new SelectList(languageList, "Value", "Text");

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(MovyEntity movy)
        {

            List<SelectListItem> genreList = GenreBL.ViewAllGenreBL().Select(n => new SelectListItem { Value = n.GenreId.ToString(), Text = n.GenreName }).ToList(); ;

            var genreTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select genre ---"
            };
            genreList.Insert(0, genreTip);
            ViewBag.generList = new SelectList(genreList, "Value", "Text");

            List<SelectListItem> languageList = LanguageBL.ViewAllLanguageBL().Select(n => new SelectListItem { Value = n.LanguageId.ToString(), Text = n.LanguageName }).ToList(); ;

            var languageTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select  Language ---"
            };
            languageList.Insert(0, languageTip);
            ViewBag.langList = new SelectList(languageList, "Value", "Text");
            bool isAdded = false;
            if (ModelState.IsValid)
            {
                isAdded = MovieBL.AddMovieBL(movy);
                if (isAdded)
                    return RedirectToAction("Index");
            }


            return View(movy);
        }

        // GET: Movies/Details/5
        public ActionResult DetailsMovie(int id)
        {

            MovyEntity movie = MovieBL.SearchMovieByIdBL(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult EditMovie(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            MovyEntity movie = MovieBL.SearchMovieByIdBL(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie(MovyEntity movy)
        {
            bool isUpdated = false;
            if (ModelState.IsValid)
            {
                isUpdated = MovieBL.UpdateMovieBL(movy);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(movy);
        }

        // GET: Movies/Delete/5
        public ActionResult DeleteMovie(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            MovyEntity movie = MovieBL.SearchMovieByIdBL(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("DeleteMovie")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovieConfirmed(int id)
        {
            bool isDeleted = false;
            isDeleted = MovieBL.DeleteMovieBL(id);
            if (isDeleted)
                return RedirectToAction("Index");
            return HttpNotFound();
        }




        //GEnre Methods
        public ActionResult IndexGenre()
        {
            List<GenreEntity> listGenre = GenreBL.ViewAllGenreBL();
            return View(listGenre);
        }

        public ActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenre(GenreEntity genre)
        {
            bool isAdded = false;
            if (ModelState.IsValid)
            {
                isAdded = GenreBL.AddGenreBL(genre);
                if (isAdded)
                    return RedirectToAction("IndexGenre");
            }


            return View(genre);
        }

        //Ticket Methods of admin
        // GET: Tickets
        // GET: Tickets
        public ActionResult IndexTickets()
        {
            var fromDate = DateTime.Parse(Request.QueryString["fromDate"]);
            var toDate = DateTime.Parse(Request.QueryString["toDate"]);
            List<TicketEntityNew> ticketList = TicketsBL.ViewAllTicketBL(fromDate, toDate);

            return View(ticketList);

        }
        public ActionResult GenerateReport()
        {
            return View();
        }
        //Post:Tickets
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateReport(FormCollection form)
        {
            DateTime fromDate = Convert.ToDateTime(form["from"].ToString());
            DateTime toDate = Convert.ToDateTime(form["to"].ToString());

            if (fromDate <= toDate)
            {
                string url = string.Format("/Admins/IndexTickets?fromDate={0}&toDate={1}", fromDate, toDate);
                return Redirect(url);

            }

            TempData["msg"] = "<script>alert('Not a Valid Date');</script>";
            return View();
        }


        //Feedback Methods
        // GET: Feedbacks
        public ActionResult IndexFeedback()
        {
            List<FeedbackEntityNew> feedbacks = FeedbackBL.ViewAllFeedbackBL();
            return View(feedbacks);
        }

        // GET: Feedbacks/Details/5
        public ActionResult DetailsFeedback(int id)
        {

            FeedbackEntity feedback = FeedbackBL.SearchFeedbackBL(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }



    }
}