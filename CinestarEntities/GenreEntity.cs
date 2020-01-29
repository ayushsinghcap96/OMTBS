using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
    public class GenreEntity
    {
       
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Genre name is required")]
        [CustomNameValidator]
        [RegularExpression("^[a-zA-Z]{1,25}$", ErrorMessage = "Invalid Genre Name")]
        public string GenreName { get; set; }

       
    }
}
