using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinestarEntities;
using CinestarExceptions;
namespace CinestarDataAccessLayer
{
    public class ShowSeatLayoutDAL
    {

        public static ShowSeatLayoutEntity ReturnSeatLayoutDAL(int showId)
        {
            CinestarEntitiesDAL cinestar = new CinestarEntitiesDAL();
            var query = from item in cinestar.ShowSeatLayouts
                        where item.ShowId == showId
                        select item;

            ShowSeatLayout layout = query.FirstOrDefault();
            ShowSeatLayoutEntity entity = new ShowSeatLayoutEntity();
            entity.LayoutId = layout.LayoutId;
            entity.ShowId = layout.ShowId;
            entity.UnavailableSeats = layout.UnavailableSeats;
            return entity;
        }

        public static bool UpdateLayoutDAL (ShowSeatLayoutEntity layout)
        {
            CinestarEntitiesDAL cinestar = new CinestarEntitiesDAL();
            ShowSeatLayout seatLayout = new ShowSeatLayout();
            seatLayout.LayoutId = layout.LayoutId;
            seatLayout.ShowId = layout.ShowId;
            seatLayout.UnavailableSeats = layout.UnavailableSeats;
            cinestar.Entry(seatLayout).State = EntityState.Modified;
            int rowsaffected=cinestar.SaveChanges();
            if (rowsaffected > 0)
                return true;
            else
                return false;
        }

        public static bool AddScreenLayout(int showId)
        {
            bool layoutAdded = false;
            try
            {
                CinestarEntitiesDAL ObjContext = new CinestarEntitiesDAL();
                var objSeatLayout = new ShowSeatLayout();
                objSeatLayout.ShowId = showId;
                objSeatLayout.LayoutId = showId;

                objSeatLayout.UnavailableSeats = string.Empty;
              
                ObjContext.ShowSeatLayouts.Add(objSeatLayout);
                int NoOfRowsAffected = ObjContext.SaveChanges();
                if (NoOfRowsAffected > 0)
                    layoutAdded = true;
            }
            catch (Exception ex)
            {
                throw new MovieExceptions("Error : Reading data", ex);
            }
            return layoutAdded;
        }

    }
}
