using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class FriendshipBLL
    {
        public int GuestSenderID { get; set; }
        public int GuestRecieverID { get; set; }

        //true - are friends; false - rejected; null - waiting for response
        public bool? Confirmed { get; set; }

        public UserBLL GuestSender { get; set; }
        public UserBLL GuestReciever { get; set; }

        public FriendshipBLL() { }

        public FriendshipBLL(Friendship friendship)
        {
            GuestSenderID = friendship.GuestSenderID;
            GuestRecieverID = friendship.GuestRecieverID;
            Confirmed = friendship.Confirmed;

            GuestSender = new UserBLL(friendship.GuestSender, "friendship");
            GuestReciever = new UserBLL(friendship.GuestReciever, "friendship");
        }
    }
}
