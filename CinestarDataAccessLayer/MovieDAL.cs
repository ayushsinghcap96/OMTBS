using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;
using System.Data.Entity;

namespace CinestarDataAccessLayer
{
   public  class MovieDAL
    {
        public List<MovyEntityNew> GetAllMoviesDAL()
        {
            List<MovyEntityNew> result = new List<MovyEntityNew>();

            CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();

            var ObjMovieList = from Movie in ObjContext.Movies
                               join Genre in ObjContext.Genres
                                on Movie.GenreId equals Genre.GenreId
                               join Language in ObjContext.Languages
                               on Movie.LanguageId equals Language.LanguageId
                               select new MovyEntityNew {
                                   Genre = Genre.GenreName,
                                   Language = Language.LanguageName,
                                   MovieDescription = Movie.MovieDescription,
                                   MovieId = Movie.MovieId,
                                   MovieName=Movie.MovieName,
                                   MovieUrl=Movie.MovieUrl,
                                   ReleaseDate=Movie.ReleaseDate

                               };


            foreach( var item in ObjMovieList)
            {
                MovyEntityNew entity = new MovyEntityNew();
                entity.Genre = item.Genre;
                entity.Language = item.Language;
                entity.MovieDescription = item.MovieDescription;
                entity.MovieId = item.MovieId;
                entity.MovieName = item.MovieName;
                entity.MovieUrl = item.MovieUrl;
                entity.ReleaseDate = item.ReleaseDate;
                result.Add(entity);
            }



            return result;
        }

        public static MovyEntity SearchMovieByIdDAL(int id)
        {
            CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();

            var movieQuery = from item in ObjContext.Movies
                             where item.MovieId == id
                             select item;
            Movy movie = ObjContext.Movies.Find(id);
            MovyEntity entity = new MovyEntity();
            entity.GenreId = movie.GenreId;
            entity.LanguageId = movie.LanguageId;
            entity.MovieDescription = movie.MovieDescription;
            entity.MovieId = movie.MovieId;
            entity.MovieName = movie.MovieName;
            entity.MovieUrl = movie.MovieUrl;
            entity.ReleaseDate = movie.ReleaseDate;
            return entity;
        }

        public bool AddMovieDAL(MovyEntity newMovie)
        {
            try
            {
                bool isAdded = false;
                var ObjContext = new CinestarEntitiesDAL();
                var objMovie = new Movy();
                objMovie.MovieId = newMovie.MovieId;
                objMovie.MovieName = newMovie.MovieName;
                objMovie.MovieUrl = newMovie.MovieUrl;
                objMovie.ReleaseDate = newMovie.ReleaseDate;
                objMovie.GenreId = newMovie.GenreId;
                objMovie.LanguageId = newMovie.LanguageId;
                objMovie.MovieDescription = newMovie.MovieDescription;

                ObjContext.Movies.Add(objMovie);
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

        public bool UpdateMovieDAL(MovyEntity updateMovie)
        {
            bool movieUpdated = false;
            var ObjContext = new CinestarEntitiesDAL();
            var objMovie = ObjContext.Movies.Find(updateMovie.MovieId);
            if (objMovie != null)
            {
                objMovie.MovieId = updateMovie.MovieId;
                objMovie.MovieName = updateMovie.MovieName;
                objMovie.MovieUrl = updateMovie.MovieUrl;
                objMovie.ReleaseDate = updateMovie.ReleaseDate;
                objMovie.GenreId = updateMovie.GenreId;
                objMovie.LanguageId = updateMovie.LanguageId;
                objMovie.MovieDescription = updateMovie.MovieDescription;
                int NoofRowsAffected = ObjContext.SaveChanges();
                movieUpdated = (NoofRowsAffected > 0);

            }
            return movieUpdated;
        }

        public bool DeleteMovieDAL(int movieId)
        {
            bool isDeleted = false;
            var objContext = new CinestarEntitiesDAL();
            var objMovie = objContext.Movies.Find(movieId);
            if (objMovie != null)
            {
                objContext.Movies.Remove(objMovie);
                int NoofRowsAffected = objContext.SaveChanges();
                isDeleted = (NoofRowsAffected > 0);
            }
            else isDeleted = false;
            return isDeleted;
        }
    }
}
