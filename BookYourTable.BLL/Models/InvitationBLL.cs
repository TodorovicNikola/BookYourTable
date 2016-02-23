using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class InvitationBLL
    {
        public int GuestID { get; set; }

        public int ReservationID { get; set; }

        public bool? Accepted { get; set; }
        public int? Grade { get; set; }

        public ReservationBLL Reservation { get; set; }
        public virtual UserBLL User { get; set; }

        public InvitationBLL(Invitation invitation)
        {
            GuestID = invitation.GuestID;
            ReservationID = invitation.ReservationID;
            Accepted = invitation.Accepted;
            Grade = invitation.Grade;
            Reservation = new ReservationBLL(invitation.Reservation);
            User = new UserBLL(invitation.Guest);
        }
    }
}
