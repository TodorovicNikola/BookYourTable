using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class MenuItemBLL
    {
        public int MenuItemID { get; set; }
        public int RestaurantID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String ImgUrl { get; set; }

        public MenuItemBLL(MenuItem menuItemDAL)
        {
            MenuItemID = menuItemDAL.MenuItemID;
            RestaurantID = menuItemDAL.RestaurantID;
            Name = menuItemDAL.Name;
            Description = menuItemDAL.Description;
            Price = menuItemDAL.Price;
            ImgUrl = menuItemDAL.ImgUrl;
        }
    }
}
