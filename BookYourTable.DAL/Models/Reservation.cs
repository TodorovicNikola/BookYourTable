using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookYourTable.DAL.Models
{
    public class Reservation
    {
        [Key]
        [Column(Order = 0)]
        public int ReservationID { get; set; }

        [ForeignKey("Guest")]
        public int GuestID { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }


        public virtual Guest Guest { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<ReservationRealization> ReservationRealizations { get; set; }
    }
}
