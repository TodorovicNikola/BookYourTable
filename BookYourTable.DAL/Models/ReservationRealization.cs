using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookYourTable.DAL.Models
{
    public class ReservationRealization
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        public Decimal Time { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Table")]
        public int TableID { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("Table")]
        public int RestaurantID { get; set; }

        [ForeignKey("Reservation")]
        public int? ReservationID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Table Table { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
