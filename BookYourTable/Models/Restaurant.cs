using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookYourTable.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "Name of the Restaurant cannot be empty!")]
        [StringLength(128, ErrorMessage = "Name cannot be longer than 128 characters!")]
        public String Name { get; set; }

        public int ImgUrl { get; set; }

        [Required(ErrorMessage = "Address of the Restaurant cannot be empty!")]
        [StringLength(256, ErrorMessage = "Address cannot be longer than 256 characters!")]
        public String Address { get; set; }
    }      
}