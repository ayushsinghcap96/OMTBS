using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarExceptions
{
    public class MovieExceptions:Exception
    {
        public MovieExceptions()
             : base()
        {

        }
        public MovieExceptions(string message)
            : base(message)
        {

        }
        public MovieExceptions(string message, Exception innerException)
           : base(message, innerException)
        {

        }
    }
}
