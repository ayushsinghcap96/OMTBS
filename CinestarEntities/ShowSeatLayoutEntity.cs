using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
    public class ShowSeatLayoutEntity
    {

        public int LayoutId { get; set; }
        public int ShowId { get; set; }
        public string UnavailableSeats { get; set; }

    }
}
