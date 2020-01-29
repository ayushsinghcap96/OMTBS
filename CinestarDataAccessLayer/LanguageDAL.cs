using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarDataAccessLayer
{
    public class LanguageDAL
    {
        public LanguageEntity SearchLanguage(int langId)
        {
            var ObjContext = new CinestarEntitiesDAL();
            Language ObjLang = ObjContext.Languages.Find(langId);
            LanguageEntity feedback = new LanguageEntity();
            if (ObjLang != null)
            {
                feedback.LanguageId = ObjLang.LanguageId;
                feedback.LanguageName = ObjLang.LanguageName;
            }


            return feedback;

        }
        public List<LanguageEntity> ViewAllLanguageDAL()
        {
            List<LanguageEntity> objGenreList = new List<LanguageEntity>();
            var objcontext = new CinestarEntitiesDAL();
            var query = from s in objcontext.Languages
                        select s;
            LanguageEntity objGenre = null;
            foreach (var newGenre in query)
            {
                objGenre = new LanguageEntity();
                objGenre.LanguageId = newGenre.LanguageId;
                objGenre.LanguageName = newGenre.LanguageName;

                objGenreList.Add(objGenre);
            }
            return objGenreList;
        }

    }
}
