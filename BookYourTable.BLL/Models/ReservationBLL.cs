using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class ReservationBLL
    {

        public int ReservationID { get; set; }

        public int GuestID { get; set; }

        public int RestaurantID { get; set; }

        public DateTime ReservationDate { get; set; }

        public RestaurantBLL Restaurant { get; set; }

        public ReservationBLL(Reservation reservation)
        {
            ReservationID = reservation.ReservationID;
            GuestID = reservation.GuestID;
            ReservationDate = reservation.ReservationDate;
            Restaurant = new RestaurantBLL(reservation.Restaurant);
        }
    }
}
