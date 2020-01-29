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
    public class ShowsBL
    {
        public static ShowEntity SearchShowByIdBL(int showId)
        {
            ShowEntity searchShow = null;
            try
            {

                searchShow = ShowsDAL.SearchShowByIdDAL(showId);
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchShow;
        }

        private static bool ValidateShow(ShowEntity show)
        {
            StringBuilder sb = new StringBuilder();
            bool validShow = true;
            List<MovyEntityNew> movie = MovieBL.GetAllMoviesBL();
            var query = from movy in movie
                        where movy.MovieId == show.MovieId
                        select movy.ReleaseDate;

            DateTime date = Convert.ToDateTime(query.FirstOrDefault());

            if (show.ShowDate < DateTime.Now || show.ShowDate < date)
            {
                validShow = false;
                sb.Append(Environment.NewLine + "Add valid Date");
            }
            if (show.Price < 0)
            {
                validShow = false;
                sb.Append(Environment.NewLine + "Price should be positive");
            }
            if (validShow == false)
                throw new MovieExceptions(sb.ToString());
            return validShow;
        }
        public static bool AddShowBL(ShowEntity newShow)
        {
            bool showAdded = false;
            try
            {
                if (ValidateShow(newShow))
                {
                    ShowsDAL showDAL = new ShowsDAL();

                    showAdded = showDAL.AddShowDAL(newShow);
                }
            }
            catch (MovieExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return showAdded;
        }
        public static List<ShowEntity> GetAllShowsBL(int id)
        {
            List<ShowEntity> showList = null;
            try
            {
                ShowsDAL showDAL = new ShowsDAL();

                showList = showDAL.ViewAllShowsDAL(id);
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return showList;
        }



        public static List<ShowEntityNew> GetAllShowsAdminBL()
        {
            List<ShowEntityNew> showList = null;
            try
            {
                ShowsDAL showDAL = new ShowsDAL();

                showList = showDAL.ViewAllShowsAdminDAL();
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return showList;
        }

        public static bool UpdateShowBL(ShowEntity updateShow)
        {
            bool showUpdated = false;
            try
            {
                if (ValidateShow(updateShow))
                {
                    ShowsDAL showDAL = new ShowsDAL();

                    showUpdated = showDAL.UpdateShowDAL(updateShow);
                }
            }

            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return showUpdated;
        }
        public static bool DeleteShowBL(int deleteShowID)
        {
            bool showDeleted = false;
            try
            {
                if (deleteShowID > 0)
                {
                    ShowsDAL showDAL = new ShowsDAL();
                    showDeleted = showDAL.DeleteShowDAL(deleteShowID);
                }
                else
                    throw new MovieExceptions("Invalid show ID");
            }
            catch (MovieExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return showDeleted;
        }

    }
}
