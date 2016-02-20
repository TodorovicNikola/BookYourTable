using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class UserBLL
    {
        public int UserID { get; set; }
        public String E_Mail { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String ImgUrl { get; set; }
        public int? RestaurantID { get; set; }
        public String Discriminator { get; set; }
        public List<FriendshipBLL> SentFriendshipRequests { get; set; }
        public List<FriendshipBLL> RecievedFriendshipRequests { get; set; }
        public RestaurantBLL Restaurant { get; set; }


        public UserBLL(Guest guest)
        {
            UserID = guest.UserID;
            E_Mail = guest.E_Mail;
            Password = guest.Password;
            FirstName = guest.FirstName;
            LastName = guest.LastName;
            Address = guest.Address;
            ImgUrl = guest.ImgUrl;
            Discriminator = typeof(Guest).Name;

            SentFriendshipRequests = new List<FriendshipBLL>();
            RecievedFriendshipRequests = new List<FriendshipBLL>();

            if(guest.SentFriendshipRequests != null)
            {
                foreach (Friendship friendship in guest.SentFriendshipRequests)
                {
                    SentFriendshipRequests.Add(new FriendshipBLL(friendship));
                }

                foreach (Friendship friendship in guest.RecievedFriendshipRequests)
                {
                    SentFriendshipRequests.Add(new FriendshipBLL(friendship));
                }
            }

        }

        public UserBLL(SystemManager systemManager)
        {
            UserID = systemManager.UserID;
            E_Mail = systemManager.E_Mail;
            Password = systemManager.Password;
            FirstName = systemManager.FirstName;
            LastName = systemManager.LastName;
            Discriminator = typeof(SystemManager).Name;
        }

        public UserBLL(RestaurantManager restaurantManager)
        {
            UserID = restaurantManager.UserID;
            E_Mail = restaurantManager.E_Mail;
            Password = restaurantManager.Password;
            FirstName = restaurantManager.FirstName;
            LastName = restaurantManager.LastName;
            RestaurantID = restaurantManager.RestaurantID;
            Discriminator = typeof(RestaurantManager).Name;
        }

        public UserBLL(UserDBReplica user)
        {
            UserID = user.UserID;
            E_Mail = user.E_Mail;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Address = user.Address;
            ImgUrl = user.ImgUrl;
            RestaurantID = user.RestaurantID;
            Discriminator = user.Discriminator;

            SentFriendshipRequests = new List<FriendshipBLL>();
            RecievedFriendshipRequests = new List<FriendshipBLL>();

            if (user.SentFriendshipRequests != null)
            {
                foreach (Friendship friendship in user.SentFriendshipRequests)
                {
                    SentFriendshipRequests.Add(new FriendshipBLL(friendship));
                }

                foreach (Friendship friendship in user.RecievedFriendshipRequests)
                {
                    RecievedFriendshipRequests.Add(new FriendshipBLL(friendship));
                }
            }

            if(user.Restaurant != null)
            {
                Restaurant = new RestaurantBLL(user.Restaurant);
            }
        }
    }
}
