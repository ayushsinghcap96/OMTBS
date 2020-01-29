using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinestarEntities;
using CinestarBusinessLogic;

namespace CinestarMovieBooking.Controllers
{
    public class TicketsController : Controller
    {

        // GET: Tickets/Details/5
        
        public ActionResult CreateTicket()
        {
            int nooftickets = int.Parse(Request.QueryString["noofseats"]);
            int viewerId = int.Parse(Request.QueryString["viewerid"]);
            int showId = int.Parse(Request.QueryString["showid"]);
            int movieId = int.Parse(Request.QueryString["movieId"]);
            string seatnos = Request.QueryString["seatnumbers"];

           
            ViewerProfileEntity viewer = ViewrProfilesBL.SearchViewerProfileByIdBL(viewerId);
            ShowEntity show = ShowsBL.SearchShowByIdBL(showId);
            MovyEntity movie = MovieBL.SearchMovieByIdBL(movieId);
            ScreenEntity screen = ScreenBL.SearchScreenByIdBL(show.ScreenId);
            ViewBag.ShowDate = show.ShowDate.ToShortDateString();
            ViewBag.ShowId = show.ShowId;
            ViewBag.ViewerId = viewer.ViewersId;
            ViewBag.MovieName = movie.MovieName;
            ViewBag.Price = show.Price * nooftickets;
            ViewBag.NameOfCustomer = viewer.FirstName + " " + viewer.LastName;
            ViewBag.ScreenName = screen.ScreenName;

            ViewBag.noOfTickets = nooftickets;
            ViewBag.seatNos = seatnos;

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTicket(TicketEntity ticket)
        {
            int nooftickets = int.Parse(Request.QueryString["noofseats"]);
            int viewerId = int.Parse(Request.QueryString["viewerid"]);
            int showId = int.Parse(Request.QueryString["showid"]);
            int movieId = int.Parse(Request.QueryString["movieId"]);
            string seatnos = Request.QueryString["seatnumbers"];

            ViewerProfileEntity viewer = ViewrProfilesBL.SearchViewerProfileByIdBL(viewerId);
            ShowEntity show = ShowsBL.SearchShowByIdBL(showId);
            MovyEntity movie = MovieBL.SearchMovieByIdBL(movieId);
            ScreenEntity screen = ScreenBL.SearchScreenByIdBL(show.ScreenId);

            TicketEntity createTicket = new TicketEntity();
            createTicket.NoOfTickets = nooftickets;
            createTicket.ShowId = showId;
            ViewBag.MovieName = movie.MovieName;
            createTicket.Price = show.Price * nooftickets;
            createTicket.ViewersId = viewer.ViewersId;
            createTicket.TransactionDate = DateTime.Now.Date;
            createTicket.MovieId = movie.MovieId;
            createTicket.Seats = seatnos;

            if (ModelState.IsValid)
            {
                var IsAdded = TicketsBL.CreateTicketBL(createTicket);
                if (IsAdded)
                {
                    return Redirect(string.Format("/Payments/CompletePayment"));

                }
                else
                {
                    return Redirect(string.Format("/SeatLayout/SelectSeatsView"));

                }

            }
            else
            {
                return Redirect(string.Format("/SeatLayout/SelectSeatsView"));

            }


        }

        public ActionResult MyTickets()
        {
            if (Session["ViewerId"] != null )
            {
                int viewerId = Convert.ToInt32(Session["ViewerId"]);
            List<TicketEntityNew> ticketList = TicketsBL.MyTicketsDAL(viewerId);
                ;


                return View(ticketList);

            }
            else
            {
                string url = string.Format("/Users/LogIn");
                return Redirect(url);
            }


        }

        public ActionResult ViewTicket(int id)
        {
            TicketEntity createTicket = new TicketEntity();
            createTicket = TicketsBL.SearchTicketByIdBL(id);

            ViewerProfileEntity viewer = ViewrProfilesBL.SearchViewerProfileByIdBL(createTicket.ViewersId);
            ShowEntity show = ShowsBL.SearchShowByIdBL(createTicket.ShowId);
            MovyEntity movie = MovieBL.SearchMovieByIdBL(createTicket.MovieId);
            ScreenEntity screen = ScreenBL.SearchScreenByIdBL(show.ScreenId);


            ViewBag.ShowDate = show.ShowDate.ToShortDateString();
            ViewBag.ShowId = show.ShowId;
            ViewBag.ViewerId = viewer.ViewersId;
            ViewBag.MovieName = movie.MovieName;
            ViewBag.Price = show.Price * createTicket.NoOfTickets;
            ViewBag.NameOfCustomer = viewer.FirstName + " " + viewer.LastName;
            ViewBag.ScreenName = screen.ScreenName;

            ViewBag.noOfTickets = createTicket.NoOfTickets;
            ViewBag.seatNos = createTicket.Seats;


            if (createTicket != null)
            {
                return View();


            }
            else
            {
                return Redirect(string.Format("/Movies/ListAllMovies"));

            }


        }


    }
}