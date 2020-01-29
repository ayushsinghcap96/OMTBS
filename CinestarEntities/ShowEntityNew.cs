using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinestarEntities
{
    public class ShowEntityNew
    {


        public int ShowId { get; set; }
        [Required(ErrorMessage = "Show date is required")]
        [DataType(DataType.Date)]
        public System.DateTime ShowDate { get; set; }
        [Required(ErrorMessage = "Show time is required")]
        [DataType(DataType.Time)]
        public System.TimeSpan ShowTime { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(100, 600, ErrorMessage = "Show price must be between 100 to 600")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Screen Id is required")]
        public string Screen { get; set; }
        public string Movie { get; set; }


    }
}
