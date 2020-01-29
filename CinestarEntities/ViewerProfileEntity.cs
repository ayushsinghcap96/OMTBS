using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
   public class ViewerProfileEntity
    {

        public int ViewersId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Invalid First name")]
        [CustomNameValidator]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Invalid Last name")]
        [CustomNameValidator]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Number should be of 10 digits")]
        [CustomNameValidator]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string EmailId { get; set; }
        public string UserName { get; set; }

    }
}
