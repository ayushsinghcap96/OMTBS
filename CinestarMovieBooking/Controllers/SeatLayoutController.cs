using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinestarBusinessLogic;
using CinestarEntities;
using CinestarExceptions;

namespace CinestarMovieBooking.Controllers
{
    public class SeatLayoutController : Controller
    {


        //// GET: layouts/Details/5
        //public ActionResult Details()
        //{

        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    ShowSeatLayout layout = cinestar.ShowSeatLayouts.Find(100);
        //    if (layout == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(layout);
        //}



        // GET: layouts/Edit/5
        public ActionResult SelectSeatsView(int showId)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ShowSeatLayoutEntity layout =ShowSeatLayoutBL.ReturnSeatLayoutBL(showId);//send show id here
            if (layout == null)
            {
                return HttpNotFound();
            }
            return View(layout);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectSeatsView(ShowSeatLayoutEntity layout, FormCollection form)
        {
            string seatsfromLayout = form["selectedseats"].ToString();
            string unavailableseatsfromLayout = form["unavailableseats"].ToString();

            string[] result = seatsfromLayout.Split('|');
            List<int> seatlist = new List<int>();
            foreach (string item in result)
            {
                int seats;
                if (int.TryParse(item, out seats))
                {
                    if (!seatlist.Contains(Convert.ToInt32(item)))
                    {
                        seatlist.Add(seats);

                    }
                }

            }
            int seatcount = seatlist.Count;
            //add new unavailable seats
            int showId = Convert.ToInt32( Request.QueryString["showId"]);
            int movieId = Convert.ToInt32(Request.QueryString["movieId"]);
            int viewerId= Convert.ToInt32(Session["ViewerId"].ToString());
            layout.UnavailableSeats = unavailableseatsfromLayout;
            string selectedseatnos = string.Join(",", seatlist);
            if (ModelState.IsValid)
            {
                bool  flag = ShowSeatLayoutBL.UpdateLayoutBL(layout);
                
                if (flag) { 
                    string url = string.Format("/Tickets/CreateTicket?noofseats={0}&seatnumbers={1}&viewerid={2}&showid={3}&movieId={4}", seatcount, selectedseatnos, viewerId, showId, movieId);
                    return Redirect(url);

                }
                else
                return View(layout);
            }



            return View(layout);
        }


        
    }
}