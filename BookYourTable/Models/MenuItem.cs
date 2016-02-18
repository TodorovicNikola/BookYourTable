using BookYourTable.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookYourTable.Models
{
    public class MenuItem
    {
        public int MenuItemID {get;set;}

        [Required(ErrorMessage = "Name cannot be empty!")]
        [StringLength(64, ErrorMessage = "Name cannot be longer than 64 characters!")]
        public String Name { get; set; }

        [StringLength(2048, ErrorMessage = "Description cannot be longer than 2048 characters!")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Price cannot be empty!")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Price can't have more than 2 decimal places")]
        [Range(0.00, 999999.99, ErrorMessage = "Price must be between 0.00 and 999999.99!")]
        public Decimal Price { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(MenuItemBLL menuItemBLL)
        {
            Name = menuItemBLL.Name;
            Description = menuItemBLL.Description;
            Price = menuItemBLL.Price;
        }
    }
}