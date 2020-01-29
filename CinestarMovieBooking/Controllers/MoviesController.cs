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
    public class MoviesController : Controller
    {
        // GET: Movies
     
        public ActionResult ListAllMovies(MovyEntityNew movie, MovyEntity movieFilter)
        {

            List<SelectListItem> genreList = GenreBL.ViewAllGenreBL().Select(n => new SelectListItem { Value = n.GenreId.ToString(), Text = n.GenreName }).ToList(); ;

            var genreTip = new SelectListItem()
            {
                Value = null,
                Text = "-- genre --"
            };
            genreList.Insert(0, genreTip);
            ViewBag.generList = new SelectList(genreList, "Value", "Text");

            List<SelectListItem> languageList = LanguageBL.ViewAllLanguageBL().Select(n => new SelectListItem { Value = n.LanguageId.ToString(), Text = n.LanguageName }).ToList(); ;

            var languageTip = new SelectListItem()
            {
                Value = null,
                Text = "--  Language --"
            };
            languageList.Insert(0, languageTip);
            ViewBag.langList = new SelectList(languageList, "Value", "Text");
            string username = Request.QueryString["username"];
            string genrename = GenreBL.SearchGenreBL(movieFilter.GenreId).GenreName;
            string languagename = LanguageBL.SearchLanguageBL(movieFilter.LanguageId).LanguageName;


            List<MovyEntityNew> listMovies = MovieBL.GetAllMoviesBL();
            var query = from item in listMovies
                        where item.Genre.Equals(genrename) || movieFilter.GenreId==0 
                        where item.Language.Equals(languagename) || movieFilter.LanguageId==0
                        select item;
            if (Session["Username"] != null && Session["ViewerId"] != null)
            {
                ViewBag.ViewerId = Session["ViewerId"];
                return View(query);

            }
            else
            {
                string url = string.Format("/Users/LogIn");
                return Redirect(url);
            }
        }
        [HttpGet]
        public ActionResult SearchAuto()
        {
            List<SelectListItem> genreList = GenreBL.ViewAllGenreBL().Select(n => new SelectListItem { Value = n.GenreId.ToString(), Text = n.GenreName }).ToList(); ;

            var genreTip = new SelectListItem()
            {
                Value = null,
                Text = "-- genre --"
            };
            genreList.Insert(0, genreTip);
            ViewBag.generList = new SelectList(genreList, "Value", "Text");

            List<SelectListItem> languageList = LanguageBL.ViewAllLanguageBL().Select(n => new SelectListItem { Value = n.LanguageId.ToString(), Text = n.LanguageName }).ToList(); ;

            var languageTip = new SelectListItem()
            {
                Value = null,
                Text = "--  Language --"
            };
            languageList.Insert(0, languageTip);
            ViewBag.langList = new SelectList(languageList, "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult SearchAuto(MovyEntity movie)
        {

            List<SelectListItem> genreList = GenreBL.ViewAllGenreBL().Select(n => new SelectListItem { Value = n.GenreId.ToString(), Text = n.GenreName }).ToList(); ;

            var genreTip = new SelectListItem()
            {
                Value = null,
                Text = "-- genre --"
            };
            genreList.Insert(0, genreTip);
            ViewBag.generList = new SelectList(genreList, "Value", "Text");

            List<SelectListItem> languageList = LanguageBL.ViewAllLanguageBL().Select(n => new SelectListItem { Value = n.LanguageId.ToString(), Text = n.LanguageName }).ToList(); ;

            var languageTip = new SelectListItem()
            {
                Value = null,
                Text = "--  Language --"
            };
            languageList.Insert(0, languageTip);
            ViewBag.langList = new SelectList(languageList, "Value", "Text");
            ////Note : you can bind same list from database  
            List<MovyEntityNew> ObjList = new List<MovyEntityNew>();
            ObjList = MovieBL.GetAllMoviesBL(); 
            ////Searching records from list using LINQ query  
            //var movieList = (from N in ObjList
            //                where N.MovieName.StartsWith(Prefix) || N.MovieName.StartsWith(Prefix.ElementAt(0).ToString().ToUpper())
            //                 select new { N.MovieName });
            //return Json(movieList, JsonRequestBehavior.AllowGet);
            var movieList = (from N in ObjList
                            where N.MovieName.ToLower().Equals(movie.MovieName.ToLower())
                             select N);
            MovyEntityNew movieResult = movieList.FirstOrDefault();
            if (movieResult != null)
            {
                string url = string.Format("/Movies/MovieDetails/" + movieResult.MovieId);
                return Redirect(url);
            }
            else
            {
                string url = string.Format("/Movies/ListAllMovies");
                return Redirect(url);

            }

        }

        [HttpPost]
        public ActionResult FilterResult(MovyEntity movie)
        {
            string username = Request.QueryString["username"];
            return RedirectToAction("ListAllMovies",movie);
            //List<MovyEntity> listMovies = MovieBL.GetAllMoviesBL();
            //var query = from item in listMovies
            //            where item.GenreId == movie.GenreId || movie.GenreId == 0 || movie.GenreId < 0
            //            where item.LanguageId == movie.LanguageId || movie.LanguageId == 0 || movie.LanguageId < 0
            //            select item;
            //if (Session["Username"] != null && Session["ViewerId"] != null)
            //{
            //    ViewBag.ViewerId = Session["ViewerId"];
            //    return View(query);

            //}
            //else
            //{
            //    string url = string.Format("/Users/LogIn");
            //    return Redirect(url);
            //}
        }

        //add view here
        // GET: Movies/Details/5
        public ActionResult MovieDetails(int id)
        {

            MovyEntity movie = MovieBL.SearchMovieByIdBL(id);
            ViewBag.language = LanguageBL.SearchLanguageBL(movie.LanguageId).LanguageName;
            ViewBag.genre = GenreBL.SearchGenreBL(movie.GenreId).GenreName;
            movie.ReleaseDate = movie.ReleaseDate.Date;
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }




    }
}