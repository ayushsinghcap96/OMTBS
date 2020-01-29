using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
    public class TicketEntity
    {
        public int Ticketid { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime TransactionDate { get; set; }
        public int NoOfTickets { get; set; }
        public int ViewersId { get; set; }
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int Price { get; set; }
        public string Seats { get; set; }


    }
}
