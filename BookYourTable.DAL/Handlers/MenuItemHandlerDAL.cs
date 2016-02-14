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
    }
}
