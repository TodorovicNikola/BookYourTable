using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BookYourTable.BLL.Models;

namespace BookYourTable.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "Name of the Restaurant cannot be empty!")]
        [StringLength(128, ErrorMessage = "Name cannot be longer than 128 characters!")]
        public String Name { get; set; }

        public String ImgUrl { get; set; }

        [Required(ErrorMessage = "Address of the Restaurant cannot be empty!")]
        [StringLength(256, ErrorMessage = "Address cannot be longer than 256 characters!")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Description of the Restaurant cannot be empty!")]
        [StringLength(256, ErrorMessage = "Description cannot be longer than 256 characters!")]
        public String Description { get; set; }

        public Boolean Configured { get; set; }
        public int? TablesMatrixWidth { get; set; }
        public int? TablesMatrixHeight { get; set; }

        public Restaurant()
        {

        }

        public Restaurant(RestaurantBLL restaurantBLL)
        {
            RestaurantID = restaurantBLL.RestaurantID;
            Name = restaurantBLL.Name;
            Description = restaurantBLL.Description;
            Address = restaurantBLL.Address;
            Configured = restaurantBLL.Configured;
            ImgUrl = restaurantBLL.ImgUrl;
            TablesMatrixWidth = restaurantBLL.TablesMatrixWidth;
            TablesMatrixHeight = restaurantBLL.TablesMatrixHeight;
        }


    }      
}