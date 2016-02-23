using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookYourTable.DAL.Models
{
    public class Guest : User
    {
        [StringLength(256)]
        public String Address { get; set; }

        [StringLength(128)]
        public String ImgUrl { get; set; }

        public bool ConfirmedRegistration { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<Friendship> SentFriendshipRequests { get; set; }
        public ICollection<Friendship> RecievedFriendshipRequests { get; set; }
    }
}
