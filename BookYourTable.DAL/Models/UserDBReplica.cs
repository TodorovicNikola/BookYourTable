using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.DAL.Models
{
    public class UserDBReplica
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
        public Restaurant Restaurant { get; set; }
        public List<Friendship> SentFriendshipRequests { get; set; }
        public List<Friendship> RecievedFriendshipRequests { get; set; }

        public UserDBReplica(Guest guest)
        {
            UserID = guest.UserID;
            E_Mail = guest.E_Mail;
            Password = guest.Password;
            FirstName = guest.FirstName;
            LastName = guest.LastName;
            Address = guest.Address;
            ImgUrl = guest.ImgUrl;
            Discriminator = typeof(Guest).Name;

            if(guest.SentFriendshipRequests != null)
            {
                SentFriendshipRequests = guest.SentFriendshipRequests.Cast<Friendship>().ToList();
                RecievedFriendshipRequests = guest.RecievedFriendshipRequests.Cast<Friendship>().ToList();
            }
        }

        public UserDBReplica(SystemManager systemManager)
        {
            UserID = systemManager.UserID;
            E_Mail = systemManager.E_Mail;
            Password = systemManager.Password;
            FirstName = systemManager.FirstName;
            LastName = systemManager.LastName;
            Discriminator = typeof(SystemManager).Name;
        }

        public UserDBReplica(RestaurantManager restaurantManager)
        {
            UserID = restaurantManager.UserID;
            E_Mail = restaurantManager.E_Mail;
            Password = restaurantManager.Password;
            FirstName = restaurantManager.FirstName;
            LastName = restaurantManager.LastName;
            RestaurantID = restaurantManager.RestaurantID;
            Discriminator = typeof(RestaurantManager).Name;
            Restaurant = restaurantManager.Restaurant;
        }
    }
}
