using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
   public  class AdminEntity
    {
        [Required(ErrorMessage = "Enter Admin name")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string AdminPassword { get; set; }
    }
}
