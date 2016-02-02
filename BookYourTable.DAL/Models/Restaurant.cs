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
        public String name { get; set; }

        [Required]
        [StringLength(1024)]
        public String description { get; set; }

        [StringLength(128)]
        public String imgUrl { get; set; }
        
        public virtual ICollection<RestaurantManager> RestaurantManagers { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
