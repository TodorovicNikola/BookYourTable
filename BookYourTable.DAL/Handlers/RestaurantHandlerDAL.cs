using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.DAL.Handlers
{
    public class RestaurantHandlerDAL
    {
        private BookYourTableDBContext _context = new BookYourTableDBContext();

        public List<Restaurant> AcquireAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant AcquireRestaurant(int? restaurantID)
        {
            return _context.Restaurants.Where(u => u.RestaurantID == restaurantID).First(); ;
        }

        public void EditRestaurant(int restaurantID, String name, String description, String address)
        {
            var restaurant = _context.Restaurants.Find(restaurantID);

            restaurant.Name = name;
            restaurant.Description = description;
            restaurant.Address = address;

            _context.SaveChanges();
        }

    }
}
