using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;

namespace CinestarDataAccessLayer
{
    public class ShowsDAL
    {
        public static ShowEntity SearchShowByIdDAL(int id)
        {
            ShowEntity searchShow = new ShowEntity();

            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();

                var ObjShow = ObjContext.Shows.Find(id);
                if (ObjShow != null)
                {
                    searchShow.ScreenId = ObjShow.ScreenId;
                    searchShow.MovieId = ObjShow.MovieId;
                    searchShow.Price = ObjShow.Price;
                    searchShow.ShowDate = ObjShow.ShowDate;
                    searchShow.ShowId = ObjShow.ShowId;
                    searchShow.ShowTime = ObjShow.ShowTime;



                }
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading searching data", ex);
            }
            return searchShow;

        }

        public List<ShowEntity> ViewAllShowsDAL(int id)
        {
            List<ShowEntity> objShowList = new List<ShowEntity>();
            CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
            var Objshow = new ShowEntity();

            var query = from show in ObjContext.Shows
                        where show.MovieId == id
                        select show;
            ShowEntity ObjTempShow = null;
            foreach (var d in query)
            {
                ObjTempShow = new ShowEntity();
                ObjTempShow.MovieId = d.MovieId;
                ObjTempShow.Price = d.Price;
                ObjTempShow.ShowId = d.ShowId;
                ObjTempShow.ScreenId = d.ScreenId;
                ObjTempShow.ShowDate = d.ShowDate;
                ObjTempShow.ShowTime = d.ShowTime;
                objShowList.Add(ObjTempShow);
            }
            return objShowList;
        }


        public bool AddShowDAL(ShowEntity newShow)
        {
            bool showAdded = false;
            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var Objshow = new Show();
                Objshow.ShowDate = newShow.ShowDate;
                Objshow.ShowTime = newShow.ShowTime;
                Objshow.MovieId = newShow.MovieId;
                Objshow.Price = newShow.Price;
                Objshow.ScreenId = newShow.ScreenId;
                ObjContext.Shows.Add(Objshow);
                int NoOfRowsAffected = ObjContext.SaveChanges();
                bool showLayoutAdded=ShowSeatLayoutDAL.AddScreenLayout(Objshow.ShowId);
        
                    if (NoOfRowsAffected > 0&& showLayoutAdded)
                    showAdded = true;

            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading data", ex);
            }
            return showAdded;
        }

        public bool UpdateShowDAL(ShowEntity updateShow)
        {
            bool showUpdated = false;
            try
            {

                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var objShow = new Show();
                objShow = ObjContext.Shows.Find(updateShow.ShowId);

                if (objShow != null)
                {
                    objShow.ShowDate = updateShow.ShowDate;
                    objShow.ShowTime = updateShow.ShowTime;
                    objShow.MovieId = updateShow.MovieId;
                    objShow.Price = updateShow.Price;
                    objShow.ScreenId = updateShow.ScreenId;

                    int NoOfRowsAffected = ObjContext.SaveChanges();
                    showUpdated = NoOfRowsAffected > 0;
                }
                else
                {
                    showUpdated = false;
                }


            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading data", ex);
            }
            return showUpdated;
        }
        public bool DeleteShowDAL(int deleteShowID)
        {
            bool showDeleted = false;
            try
            {

                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var objShow = new Show();
                objShow = ObjContext.Shows.Find(deleteShowID);

                if (objShow != null)
                {
                    ObjContext.Shows.Remove(objShow);
                    int NoOfRowsAffected = ObjContext.SaveChanges();
                    showDeleted = NoOfRowsAffected > 0;
                }
                else
                {
                    showDeleted = false;
                }

            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading data", ex);
            }
            return showDeleted;
        }
        public List<ShowEntityNew> ViewAllShowsAdminDAL()
        {
            List<ShowEntityNew> result = new List<ShowEntityNew>();
            CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
            var Objshow = new ShowEntity();


            var ObjMovieList = from Shows in ObjContext.Shows
                               join Movie in ObjContext.Movies
                                on Shows.MovieId equals Movie.MovieId
                               join Screen in ObjContext.Screens
                               on Shows.ScreenId equals Screen.ScreenId
                               select new ShowEntityNew
                               {
                                   Movie = Movie.MovieName,
                                   Screen=Screen.ScreenName,
                                   Price=Shows.Price,
                                   ShowDate=Shows.ShowDate,
                                   ShowId=Shows.ShowId,
                                   ShowTime=Shows.ShowTime
                                   

                               };

            foreach (var item in ObjMovieList)
            {
                ShowEntityNew temp = new ShowEntityNew();
                temp.Movie = item.Movie;
                temp.Price = item.Price;
                temp.Screen = item.Screen;
                temp.ShowDate = item.ShowDate;
                temp.ShowId = item.ShowId;
                temp.ShowTime = item.ShowTime;
                result.Add(temp);
            }
            return result;
        }

    }
}

