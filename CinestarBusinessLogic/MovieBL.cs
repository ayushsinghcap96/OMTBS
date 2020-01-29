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
     public class MovieBL
    {

        private static bool ValidateMovie(MovyEntity movie)
        {
            StringBuilder sd = new StringBuilder();
            bool validMovie = true;

            if (movie.MovieName == string.Empty)
            {
                validMovie = false;
                sd.Append(Environment.NewLine + "Movie Name required");
            }
            if (movie.MovieDescription == string.Empty)
            {
                validMovie = false;
                sd.Append(Environment.NewLine + "Movie description required");
            }
            return validMovie;
        }
        public static List<MovyEntityNew> GetAllMoviesBL()
        {
            List<MovyEntityNew> movieList = null;
            try
            {
                MovieDAL movieDAL = new MovieDAL();
                movieList = movieDAL.GetAllMoviesDAL();
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return movieList;
        }

        public static MovyEntity SearchMovieByIdBL(int id)
        {
            
            return MovieDAL.SearchMovieByIdDAL(id);
        }

        public static bool AddMovieBL(MovyEntity newMovie)
        {
            bool movieAdded = false;
            if (ValidateMovie(newMovie))
            {
                MovieDAL movieOperations = new MovieDAL();
                movieAdded = movieOperations.AddMovieDAL(newMovie);
            }
            return movieAdded;
        }


        public static bool UpdateMovieBL(MovyEntity objMovie)
        {
            bool isUpdated = false;
            if (ValidateMovie(objMovie))
            {
                MovieDAL movieOperations = new MovieDAL();
                isUpdated = movieOperations.UpdateMovieDAL(objMovie);
            }
            return isUpdated;
        }

        public static bool DeleteMovieBL(int movieId)
        {
            bool isDeleted = false;
            MovieDAL movieOperations = new MovieDAL();
            isDeleted = movieOperations.DeleteMovieDAL(movieId);
            return isDeleted;
        }
    }
}
