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
    public class LanguageBL
    {
        public static LanguageEntity SearchLanguageBL(int LAngId)
        {
            LanguageEntity feedback;
            LanguageDAL langDAL = new LanguageDAL();
            feedback = langDAL.SearchLanguage(LAngId);

            return feedback;
        }
        public static List<LanguageEntity> ViewAllLanguageBL()
        {
            List<LanguageEntity> lanList = null;
            LanguageDAL langDAL = new LanguageDAL();
            lanList = langDAL.ViewAllLanguageDAL();
            return lanList;

        }
    }
}
