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

        [Key]
        [ForeignKey("Table")]
        [Column(Order = 1)]
        public int TableID { get; set; }

        [Key]
        [ForeignKey("Table")]
        [Column(Order = 2)]
        public int RestaurantID { get; set; }

        [Required]
        [ForeignKey("Guest")]
        public int GuestID { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public float Period { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }

    }
}
