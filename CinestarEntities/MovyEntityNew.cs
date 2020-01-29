using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
    public class MovyEntityNew
    {


        public int MovieId { get; set; }
        [Required(ErrorMessage = "Movie name is required")]
        [RegularExpression("^[a-zA-Z0-9\\s]{1,60}$", ErrorMessage = "Maximum length:60, Special characters are not allowed.")]
        [CustomNameValidator]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public System.DateTime ReleaseDate { get; set; }
        public string Genre{ get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Movie description is Required")]
        [RegularExpression("^[a-zA-Z0-9\\s]{1,1000}$", ErrorMessage = "Maximum length:1000, Special characters are not allowed.")]
        [CustomNameValidator]

        public string MovieDescription { get; set; }
        [Required(ErrorMessage = "Movie URL is required")]
        [RegularExpression("^[a-zA-Z0-9\\s.,-?:;+=()_*&^$#@/\']{1,200}$", ErrorMessage = "Maximum length:200, Special characters and white spaces are not allowed.")]
        [CustomNameValidator]
        public string MovieUrl { get; set; }


    }
}
