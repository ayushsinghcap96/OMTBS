using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CinestarEntities;
using CinestarExceptions;
namespace CinestarDataAccessLayer
{
    public class GenreDAL
    {
        public bool AddGenreDAL(GenreEntity newGenre)
        {
            try
            {
                bool isAdded = false;
                var ObjContext = new CinestarEntitiesDAL();
                var objGenre = new Genre();
                objGenre.GenreId = newGenre.GenreId;
                objGenre.GenreName = newGenre.GenreName;

                ObjContext.Genres.Add(objGenre);
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
        public GenreEntity SearchGenre(int genreId)
        {
            var ObjContext = new CinestarEntitiesDAL();
            Genre ObjLang = ObjContext.Genres.Find(genreId);
            GenreEntity genre = new GenreEntity();
            if (ObjLang != null)
            {
                genre.GenreId = ObjLang.GenreId;
                genre.GenreName = ObjLang.GenreName;
            }


            return genre;

        }
        public List<GenreEntity> ViewAllGenreDAL()
        {
            List<GenreEntity> objGenreList = new List<GenreEntity>();
            var objcontext = new CinestarEntitiesDAL();
            var query = from s in objcontext.Genres
                        select s;
            GenreEntity objGenre = null;
            foreach (var newGenre in query)
            {
                objGenre = new GenreEntity();
                objGenre.GenreId = newGenre.GenreId;
                objGenre.GenreName = newGenre.GenreName;

                objGenreList.Add(objGenre);
            }
            return objGenreList;
        }

    }
}
