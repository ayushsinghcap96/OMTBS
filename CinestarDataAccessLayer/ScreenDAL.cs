using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarDataAccessLayer
{
    public class ScreenDAL
    {
        public static ScreenEntity SearchScreenByIdDAL(int id)
        {
            ScreenEntity searchScreen = new ScreenEntity();

            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();

                var ObjScreen = ObjContext.Screens.Find(id);
                if (ObjScreen != null)
                {
                    searchScreen.ScreenId = ObjScreen.ScreenId;
                    searchScreen.ScreenName = ObjScreen.ScreenName;
                    
                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading searching data", ex);
            }
            return searchScreen;

        }
        public List<ScreenEntity> ViewAllScreenDAL()
        {
            List<ScreenEntity> ObjLanguageList = new List<ScreenEntity>();
            var objcontext = new CinestarEntitiesDAL();
            var query = from s in objcontext.Screens
                        select s;
            ScreenEntity objLanguageL = null;
            foreach (var newGenre in query)
            {
                objLanguageL = new ScreenEntity();
                objLanguageL.ScreenId = newGenre.ScreenId;
                objLanguageL.ScreenName = newGenre.ScreenName;

                ObjLanguageList.Add(objLanguageL);
            }
            return ObjLanguageList;
        }
    }
}
