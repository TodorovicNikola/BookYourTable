using BookYourTable.BLL.Models;
using BookYourTable.DAL.Handlers;
using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Handlers
{
    public class MenuItemHandlerBLL
    {
        MenuItemHandlerDAL _menuItemHandlerDAL = new MenuItemHandlerDAL();

        public List<MenuItemBLL> AcquireAllMenuItems(int restaurantID)
        {
            List<MenuItem> menuItemsDAL = _menuItemHandlerDAL.AcquireAllMenuItems(restaurantID);
            List<MenuItemBLL> retList = new List<MenuItemBLL>();

            foreach (MenuItem menuItemDAL in menuItemsDAL)
            {
                retList.Add(new MenuItemBLL(menuItemDAL));
            }

            return retList;
        }

        public MenuItemBLL AcquireMenuItem(int restaurantID, int menuItemID)
        {
            return new MenuItemBLL(_menuItemHandlerDAL.AcquireMenuItem(restaurantID, menuItemID));
        }

        public void AddMenuItem(int restaurantID, String name, String description, Decimal price)
        {
            _menuItemHandlerDAL.AddMenuItem(restaurantID, name, description, price);
        }

        public void EditMenuItem(int restaurantID, int menuItemID, String name, String description, Decimal price)
        {
            _menuItemHandlerDAL.EditMenuItem(restaurantID, menuItemID, name, description, price);
        }

        public void DeleteMenuItem(int restaurantID, int menuItemID)
        {
            _menuItemHandlerDAL.DeleteMenuItem(restaurantID, menuItemID);
        }
    }
}
