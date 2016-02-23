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
    public class RestaurantHandlerBLL
    {
        private RestaurantHandlerDAL _restaurantHandlerDAL = new RestaurantHandlerDAL();

        public List<RestaurantBLL> AcquireAllRestaurants(String discriminator, bool sortType)//true - name, false - description
        {
            List<RestaurantBLL> restaurantsBLL = new List<RestaurantBLL>();

            var restaurantsDAL = _restaurantHandlerDAL.AcquireAllRestaurants(discriminator, sortType);

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

        public UserBLL ConfigureTables(int restaurantID, List<int> tableIndexes, int width, int height, int userID)
        {
            return new UserBLL(_restaurantHandlerDAL.ConfigureTables(restaurantID, tableIndexes, width, height, userID));
        }

        public RestaurantBLL AcquireRestaurantForBooking(int restaurantID)
        {
            return new RestaurantBLL(_restaurantHandlerDAL.AcquireRestaurantForBooking(restaurantID));
        }

        public RestaurantBLL AcquireRestaurantForBooking(int restaurantID, String date, String time, int duration)
        {
            return new RestaurantBLL(_restaurantHandlerDAL.AcquireRestaurantForBooking(restaurantID, date, time, duration));
        }

        public int ConfirmBookingTable(List<int> tableIndexes, int restaurantID, String date, String time, int duration, int userID, out UserBLL userBLL, out int? reservationID)
        {
            Guest guestDAL = new Guest();

            int retVal = _restaurantHandlerDAL.ConfirmBookingTable(tableIndexes, restaurantID, date, time, duration, userID, out guestDAL, out reservationID);

            if(retVal == 0)
            {
                userBLL = new UserBLL(guestDAL);
            }
            else
            {
                userBLL = null;
            }

            return retVal;
        }

        public void Invite(List<int> friendsIDsList, int reservationID)
        {
            _restaurantHandlerDAL.Invite(friendsIDsList, reservationID);
        }

        public void RespondToInvitation(int? userID, int? reservationID, Boolean response)
        {
            _restaurantHandlerDAL.RespondToInvitation(userID, reservationID, response);
        }

        public Decimal AcquaireAverageRating(int? restaurantID)
        {
            return _restaurantHandlerDAL.AcquaireAverageRating(restaurantID);
        }

        public Decimal AcquaireAverageRatingUser(int? restaurantID, int? userID)
        {
            return _restaurantHandlerDAL.AcquaireAverageRatingUser(restaurantID, userID);

        }
            
    }
}
