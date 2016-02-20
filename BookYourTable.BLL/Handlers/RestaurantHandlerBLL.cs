﻿using BookYourTable.BLL.Models;
using BookYourTable.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Handlers
{
    public class RestaurantHandlerBLL
    {
        private RestaurantHandlerDAL _restaurantHandlerDAL = new RestaurantHandlerDAL();

        public List<RestaurantBLL> AcquireAllRestaurants(String discriminator)
        {
            List<RestaurantBLL> restaurantsBLL = new List<RestaurantBLL>();

            var restaurantsDAL = _restaurantHandlerDAL.AcquireAllRestaurants(discriminator);

            foreach (var restaurantDAL in restaurantsDAL)
            {
                restaurantsBLL.Add(new RestaurantBLL(restaurantDAL));
            }

            return restaurantsBLL;
        }

        public RestaurantBLL AcquireRestaurant(int? restaurantID)
        {
            return new RestaurantBLL(_restaurantHandlerDAL.AcquireRestaurant(restaurantID));
        }

        public void EditRestaurant(int restaurantID, String name, String description, String address)
        {
            _restaurantHandlerDAL.EditRestaurant(restaurantID, name, description, address);
        }

        public void RemoveRestaurant(int restaurantID)
        {
            _restaurantHandlerDAL.RemoveRestaurant(restaurantID);
        }

        public void ConfigureTables(int restaurantID, List<int> tableIndexes, int width, int height)
        {
            _restaurantHandlerDAL.ConfigureTables(restaurantID, tableIndexes, width, height);
        }
    }
}
