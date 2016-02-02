using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookYourTable.DAL.Models
{
    public class Invitation
    {
        [Key]
        [ForeignKey("Guest")]
        [Column(Order = 0)]
        public int GuestID { get; set; }

        [Key]
        [ForeignKey("Reservation")]
        [Column(Order = 1)]
        public int RestaurantID { get; set; }

        [Key]
        [ForeignKey("Reservation")]
        [Column(Order = 2)]
        public int TableID { get; set; }

        [Key]
        [ForeignKey("Reservation")]
        [Column(Order = 3)]
        public int ReservationID { get; set; }

        public bool? Accepted { get; set; }
        public int? Grade { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Guest Guest { get; set; }
    }
}
