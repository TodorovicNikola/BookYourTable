using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookYourTable.DAL.Models
{
    public class RestaurantManager : User
    {
        [Required]
        public int RestaurantID { get; set; }

        [ForeignKey("RestaurantID")]
        public virtual Restaurant Restaurant { get; set; }
    }
}
