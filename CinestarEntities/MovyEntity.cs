using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
    public class MovyEntity
    {


        public int MovieId { get; set; }
        [Required(ErrorMessage = "Movie name is required")]
        [RegularExpression("^.{1,60}$", ErrorMessage = "Maximum length:60, Special characters are not allowed.")]
        [CustomNameValidator]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public System.DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "Movie description is Required")]
        [RegularExpression("^.{1,3000}$", ErrorMessage = "Maximum length:3000, Special characters are not allowed.")]
        [CustomNameValidator]

        public string MovieDescription { get; set; }
        [Required(ErrorMessage = "Movie URL is required")]
        [RegularExpression("^.{1,200}$", ErrorMessage = "Maximum length:200, Special characters and white spaces are not allowed.")]
        [CustomNameValidator]
        public string MovieUrl { get; set; }


    }
}
