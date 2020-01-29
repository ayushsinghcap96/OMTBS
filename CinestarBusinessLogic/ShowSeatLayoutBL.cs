using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarDataAccessLayer;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarBusinessLogic
{
    public class ShowSeatLayoutBL
    {

        public static ShowSeatLayoutEntity ReturnSeatLayoutBL(int showId)
        {

            ShowSeatLayoutEntity layout = ShowSeatLayoutDAL.ReturnSeatLayoutDAL(showId);
            return layout;
        }
        public static bool UpdateLayoutBL(ShowSeatLayoutEntity layout)
        {
            return ShowSeatLayoutDAL.UpdateLayoutDAL(layout);
        }


    }
}
