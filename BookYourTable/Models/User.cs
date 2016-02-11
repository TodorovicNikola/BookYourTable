using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookYourTable.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "E-Mail cannot be empty!")]
        [StringLength(64, ErrorMessage = "E-Mail cannot be longer than 64 characters!")]
        [EmailAddress(ErrorMessage ="Invalid 'E-Mail Address'!")]
        [Display(Name = "E-Mail")]
        public String E_Mail { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        [StringLength(64, ErrorMessage = "Password cannot be longer than 64 characters!")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Confirm Password cannot be empty!")]
        [Display(Name = "Confirm Password")]
        public String ConfirmPassword { get; set; }

        [Display(Name = "First Name")]
        [StringLength(32, ErrorMessage = "First Name cannot be longer than 32 characters!")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(32, ErrorMessage = "Last Name cannot be longer than 32 characters!")]
        public String LastName { get; set; }

        [StringLength(256, ErrorMessage = "Address cannot be longer than 256 characters!")]
        public String Address { get; set; }

        public String ImgUrl { get; set; }

        public int RestaurantID { get; set; }

        public String Discriminator { get; set; }


    }
}