using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarDataAccessLayer;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarBusinessLogic
{
    public class TicketsBL
    {
        public static bool CreateTicketBL(TicketEntity newTicket)
        {
            bool userAdded = false;
            try
            {
               
                    TicketsDAL ticketDAL = new TicketsDAL();
                    userAdded = ticketDAL.CreateTicketDAL(newTicket);
                
            }
            catch (MovieExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userAdded;
        }

        public static List<TicketEntityNew> ViewAllTicketBL(DateTime fromDate, DateTime toDate)
        {
            List<TicketEntityNew> ticketList = null;
            TicketsDAL ticketDAL = new TicketsDAL();
            ticketList = ticketDAL.ViewAllTicketDAL(fromDate, toDate);
            return ticketList;
        }
        public static List<TicketEntityNew> MyTicketsDAL(int viewerId)
        {
            List<TicketEntityNew> ticketList = null;
            TicketsDAL ticketDAL = new TicketsDAL();
            ticketList = ticketDAL.MyTicketsDAL(viewerId);
            return ticketList;
        }
        public static TicketEntity SearchTicketByIdBL(int id)
        {
            TicketEntity ticket = TicketsDAL.SearchTicketById(id);
            return ticket;
        }

    }
}
