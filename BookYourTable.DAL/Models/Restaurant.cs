using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookYourTable.DAL.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        [StringLength(128)]
        [Required]
        public String Name { get; set; }

        [Required]
        [StringLength(256)]
        public String Description { get; set; }

        [StringLength(128)]
        public String ImgUrl { get; set; }

        [Required]
        [StringLength(256)]
        public String Address { get; set; }

        [Required]
        public bool Configured { get; set; }

        public int? TablesMatrixWidth { get; set; }
        public int? TablesMatrixHeight { get; set; }
        
        public ICollection<RestaurantManager> RestaurantManagers { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public ICollection<Table> Tables { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
