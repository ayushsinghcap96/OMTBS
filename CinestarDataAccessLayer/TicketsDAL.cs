using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;

namespace CinestarDataAccessLayer
{
    public class TicketsDAL
    {
        public bool CreateTicketDAL(TicketEntity newTicket)
        {
            bool ticketAdded = false;
            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                Ticket ObjTicket = new Ticket();
                ObjTicket.NoOfTickets = newTicket.NoOfTickets;
                ObjTicket.ShowId = newTicket.ShowId;
                ObjTicket.Price = newTicket.Price;
                ObjTicket.ViewersId = newTicket.ViewersId;
                ObjTicket.TransactionDate = newTicket.TransactionDate;
                ObjTicket.MovieId = newTicket.MovieId;
                ObjTicket.Seats = newTicket.Seats;


                ObjContext.Tickets.Add(ObjTicket);
                int NoOfRowsAffected = ObjContext.SaveChanges();
                if (NoOfRowsAffected > 0)
                {
                    ticketAdded = true;
                }
                else
                {
                    ticketAdded = false;
                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading data", ex);
            }
            return ticketAdded;
        }

        public List<TicketEntityNew> ViewAllTicketDAL(DateTime fromDate, DateTime toDate)
        {
            var objcontext = new CinestarEntitiesDAL();
            var query = from tickets in objcontext.Tickets
                        join movie in objcontext.Movies
                        on tickets.MovieId equals movie.MovieId
                        join show in objcontext.Shows
                        on tickets.ShowId equals show.ShowId
                        join viewer in objcontext.ViewerProfiles
                        on tickets.ViewersId equals viewer.ViewersId
                        where tickets.TransactionDate >= fromDate && tickets.TransactionDate <= toDate
                        select new TicketEntityNew
                        {
                            Movie = movie.MovieName,
                            NoOfTickets=tickets.NoOfTickets,
                            Price=tickets.Price,
                            Seats=tickets.Seats,
                            ShowDate=show.ShowDate,
                            Ticketid=tickets.Ticketid,
                            TransactionDate=tickets.TransactionDate,
                            ViewerName=viewer.FirstName+" "+viewer.LastName
                        }; 


            return query.ToList(); 
        }

        public List<TicketEntityNew> MyTicketsDAL(int id)
        {
            
            var objcontext = new CinestarEntitiesDAL();
            var query = from tickets in objcontext.Tickets
                        join movie in objcontext.Movies
                        on tickets.MovieId equals movie.MovieId
                        join show in objcontext.Shows
                        on tickets.ShowId equals show.ShowId
                        join viewer in objcontext.ViewerProfiles
                        on tickets.ViewersId equals viewer.ViewersId
                        where tickets.ViewersId==id
                        select new TicketEntityNew
                        {
                            Movie = movie.MovieName,
                            NoOfTickets = tickets.NoOfTickets,
                            Price = tickets.Price,
                            Seats = tickets.Seats,
                            ShowDate = show.ShowDate,
                            Ticketid = tickets.Ticketid,
                            TransactionDate = tickets.TransactionDate,
                            ViewerName = viewer.FirstName + " " + viewer.LastName
                        };


            return query.ToList();
        }
        public static TicketEntity SearchTicketById(int id)
        {
            TicketEntity objTicket = new TicketEntity();

            var objcontext = new CinestarEntitiesDAL();
            Ticket ticket = objcontext.Tickets.Find(id);

            objTicket.MovieId = ticket.MovieId;
            objTicket.Price = ticket.Price;
            objTicket.NoOfTickets = ticket.NoOfTickets;
                objTicket.ShowId = ticket.ShowId;
                objTicket.Ticketid = ticket.Ticketid;
                objTicket.TransactionDate = ticket.TransactionDate;
                objTicket.ViewersId = ticket.ViewersId;
                objTicket.Seats = ticket.Seats;


            
            return objTicket; ;
        }
    }
}
