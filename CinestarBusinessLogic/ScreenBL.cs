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
    public class ScreenBL
    {
        public static ScreenEntity SearchScreenByIdBL(int screenId)
        {
            ScreenEntity searchScreen = null;
            try
            {

                searchScreen = ScreenDAL.SearchScreenByIdDAL(screenId);
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchScreen;
        }
        public static List<ScreenEntity> ViewAllScreenBL()
        {
            List<ScreenEntity> lanList = null;
            ScreenDAL langDAL = new ScreenDAL();
            lanList = langDAL.ViewAllScreenDAL();
            return lanList;

        }
    }
}
