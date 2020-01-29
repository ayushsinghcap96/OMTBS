using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CinestarEntities
{
   public  class UserEntity
    {


        [Required(ErrorMessage = "Enter Username")]
        [RegularExpression("^[a-zA-Z0-9.@]{1,15}$", ErrorMessage = "Invalid Username")]
        [CustomNameValidator]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [RegularExpression("^[A-Z][A-Za-z0-9]{7,}$", ErrorMessage = "Password format is wrong: 1.First character should be Uppercase \n 2.Minimum 8 characters required ")]
        public string Password { get; set; }

    }
}
