using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinestarEntities
{
    public class TicketEntityNew
    {
        public int Ticketid { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime TransactionDate { get; set; }
        public int NoOfTickets { get; set; }
        public string  ViewerName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShowDate { get; set; }
        public string Movie { get; set; }
        public int Price { get; set; }
        public string Seats { get; set; }
    }
}
