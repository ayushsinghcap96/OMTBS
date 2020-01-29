using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CinestarEntities
{
    public class FeedbackEntityNew
    {
        public int FeedbackId { get; set; }
        [Required(ErrorMessage = "Feedback details is required")]
        [RegularExpression("^[a-zA-Z0-9]{1,200}$", ErrorMessage = "Invalid")]
        [CustomNameValidator]
        public string FeedbackDetails { get; set; }
        public string  Viewer { get; set; }
    }
}
