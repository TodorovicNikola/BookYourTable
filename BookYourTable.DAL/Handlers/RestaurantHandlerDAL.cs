using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.DAL.Handlers
{
    public class RestaurantHandlerDAL
    {
        private BookYourTableDBContext _context = new BookYourTableDBContext();

        public List<Restaurant> AcquireAllRestaurants(String discriminator)
        {
            if (discriminator.Equals("SystemManager"))
            {
                return _context.Restaurants.ToList();
            }

            return _context.Restaurants.Where(u => u.Configured == true).ToList();
        }

        public Restaurant AcquireRestaurant(int? restaurantID)
        {
            return _context.Restaurants.Include(x => x.Tables).Include(x => x.MenuItems).Where(r => r.RestaurantID == restaurantID).First();
        }

        public void EditRestaurant(int restaurantID, String name, String description, String address)
        {
            var restaurant = _context.Restaurants.Find(restaurantID);

            restaurant.Name = name;
            restaurant.Description = description;
            restaurant.Address = address;

            _context.SaveChanges();
        }

        public void RemoveRestaurant(int restaurantID)
        {
            _context.Restaurants.Find(restaurantID).Configured = false;
            _context.SaveChanges();
        }

        public void ConfigureTables(int restaurantID, List<int> tableIndexes, int width, int height)
        {
            List<Table> tables = new List<Table>();

            foreach(int tableIndex in tableIndexes)
            {
                Table table = new Table() { RestaurantID = restaurantID, CellNumber = tableIndex };
                tables.Add(table);
            }

            _context.Tables.AddRange(tables);

            Restaurant restaurant = _context.Restaurants.Find(restaurantID);
            restaurant.TablesMatrixWidth = width;
            restaurant.TablesMatrixHeight = height;
            restaurant.Configured = true;

            _context.SaveChanges();
        }

    }
}
