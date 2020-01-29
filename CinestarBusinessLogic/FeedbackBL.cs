using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CinestarEntities;
using CinestarDataAccessLayer;
using CinestarExceptions;

namespace CinestarBusinessLogic
{
     public class FeedbackBL
    {
        public static List<FeedbackEntityNew> ViewAllFeedbackBL()
        {
            List<FeedbackEntityNew> feedbackList = null;
            FeedbackDAl feedbackDAL = new FeedbackDAl ();
            feedbackList = feedbackDAL.ViewAllFeedbackDAL ();
            return feedbackList;
        }

        public static FeedbackEntity SearchFeedbackBL(int feedbackId)
        {
            FeedbackEntity feedback;
            FeedbackDAl  feedbackDAL = new FeedbackDAl ();
            feedback = feedbackDAL.SearchFeedbackDAL (feedbackId);

            return feedback;
        }

        public static bool GiveFeedbackBL(FeedbackEntity newFeedback)
        {
            bool movieAdded = false;
          
                FeedbackDAl feedback = new FeedbackDAl();
                movieAdded = feedback.GiveFeedbackDAL(newFeedback);
            
            return movieAdded;
        }
    }
}
