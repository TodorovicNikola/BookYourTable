using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class ReservationRealizationBLL
    {
        public DateTime Date { get; set; }

        public Decimal Time { get; set; }

        public int TableID { get; set; }

        public int RestaurantID { get; set; }

        public int? ReservationID { get; set; }

        public ReservationRealizationBLL(ReservationRealization reservationRealizationDAL)
        {
            Date = reservationRealizationDAL.Date;
            Time = reservationRealizationDAL.Time;
            TableID = reservationRealizationDAL.TableID;
            RestaurantID = reservationRealizationDAL.RestaurantID;
            ReservationID = reservationRealizationDAL.ReservationID;
        }
    }
}
