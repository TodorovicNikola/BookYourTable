using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.DAL.Handlers
{
    public class MenuItemHandlerDAL
    {
        BookYourTableDBContext _context = new BookYourTableDBContext();

        public List<MenuItem> AcquireAllMenuItems(int restaurantID)
        {
            return _context.MenuItems.Where(m => m.RestaurantID == restaurantID).ToList();
        }

        public MenuItem AcquireMenuItem(int restaurantID, int menuItemID)
        {
            return _context.MenuItems.Where(m => m.RestaurantID == restaurantID && m.MenuItemID == menuItemID).First();
        }

        public void AddMenuItem(int restaurantID, String name, String description, Decimal price)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Name = name;
            menuItem.Description = description;
            menuItem.Price = price;
            menuItem.RestaurantID = restaurantID;

            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }

        public void EditMenuItem(int restaurantID, int menuItemID, String name, String description, Decimal price)
        {
            MenuItem menuItem = _context.MenuItems.Where(u => u.MenuItemID == menuItemID && u.RestaurantID == restaurantID).First();
            menuItem.Name = name;
            menuItem.Description = description;
            menuItem.Price = price;
            _context.SaveChanges();
        }

        public void DeleteMenuItem(int restaurantID, int menuItemID)
        {
            MenuItem menuItem = (from m in _context.MenuItems
                                 where m.RestaurantID == restaurantID && m.MenuItemID == menuItemID
                                 select m).First();
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
        }
    }
}
