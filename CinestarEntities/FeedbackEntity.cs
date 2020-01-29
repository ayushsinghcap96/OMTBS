using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinestarEntities
{
   public class FeedbackEntity
    {
        public int FeedbackId { get; set; }
        [Required(ErrorMessage = "Feedback details is required")]
        [RegularExpression("^.{1,200}$", ErrorMessage = "Invalid")]
        [CustomNameValidator]
        public string FeedbackDetails { get; set; }
        public int ViewersId { get; set; }

    }
}
