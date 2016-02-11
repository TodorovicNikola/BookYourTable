using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookYourTable.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int TableID { get; set; }
        public int RestaurantID { get; set; }

        public int GuestID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat()]
        public DateTime DateAndTime { get; set; }
    }
}
