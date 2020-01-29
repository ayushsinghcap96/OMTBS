using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarDataAccessLayer
{
    public class FeedbackDAl
    {
        public List<FeedbackEntityNew> ViewAllFeedbackDAL()
        {
            var objcontext = new CinestarEntitiesDAL();
            var query = from feedback in objcontext.Feedbacks
                        join viewer in objcontext.ViewerProfiles
                        on feedback.ViewersId equals viewer.ViewersId
                        select new FeedbackEntityNew {
                            Viewer=viewer.FirstName+" "+viewer.LastName,
                            FeedbackDetails=feedback.FeedbackDetails,
                            FeedbackId=feedback.FeedbackId
                        };
           
            return query.ToList();
        }

        public FeedbackEntity SearchFeedbackDAL(int feedbackId)
        {
            var ObjContext = new CinestarEntitiesDAL();
            var objFeedback = ObjContext.Feedbacks.Find(feedbackId);
            FeedbackEntity feedback = new FeedbackEntity();
            if (objFeedback != null)
            {
                feedback.FeedbackId = objFeedback.FeedbackId;
                feedback.FeedbackDetails = objFeedback.FeedbackDetails;
                feedback.ViewersId = objFeedback.ViewersId;
            }


            return feedback;

        }

        public bool GiveFeedbackDAL(FeedbackEntity newFeedback)
        {
            try
            {
                bool isAdded = false;
                var ObjContext = new CinestarEntitiesDAL();
                var objFeedback = new Feedback();
                objFeedback.FeedbackId = newFeedback.FeedbackId;
                objFeedback.FeedbackDetails = newFeedback.FeedbackDetails;
                objFeedback.ViewersId = newFeedback.ViewersId;
               
                ObjContext.Feedbacks.Add(objFeedback);
                int NoOfrowsAffected = ObjContext.SaveChanges();
                if (NoOfrowsAffected > 0)
                {
                    isAdded = true;

                }

                return isAdded;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

    }
}
