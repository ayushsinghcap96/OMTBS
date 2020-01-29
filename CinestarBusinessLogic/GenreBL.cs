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
   public class GenreBL
    {
        private static bool ValidateGenre(GenreEntity genre)
        {
            StringBuilder sd = new StringBuilder();
            bool validGenre = true;
            if (genre.GenreName == string.Empty)
            {
                validGenre = false;
                sd.Append(Environment.NewLine + "Genre Name required");
            }

            return validGenre;
        }

        public static bool AddGenreBL(GenreEntity newGenre)
        {
            bool genreAdded = false;
            if (ValidateGenre(newGenre))
            {
                GenreDAL genreDAL = new GenreDAL();
                genreAdded = genreDAL.AddGenreDAL(newGenre);
            }
            return genreAdded;
        }

        public static GenreEntity SearchGenreBL(int genreId)
        {
            GenreEntity feedback;
            GenreDAL langDAL = new GenreDAL();
            feedback = langDAL.SearchGenre(genreId);

            return feedback;
        }

        public static List<GenreEntity> ViewAllGenreBL()
        {
            List<GenreEntity> genreList = null;
            GenreDAL genreDAL = new GenreDAL();
            genreList = genreDAL.ViewAllGenreDAL();
            return genreList;
        }

    }
}
