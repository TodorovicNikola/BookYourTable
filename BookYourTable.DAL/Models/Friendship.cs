using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookYourTable.DAL.Models
{
    public class Friendship
    {
        [Key]
        [Column(Order = 0)]
        public int GuestSenderID { get; set; }
   
        [Key]
        [Column(Order = 1)]
        public int GuestRecieverID { get; set; }

        //true - are friends; false - rejected; null - waiting for response
        public bool? Confirmed { get; set; }

        [ForeignKey("GuestSenderID")]
        [InverseProperty("SentFriendshipRequests")]
        public virtual Guest GuestSender { get; set; }

        [ForeignKey("GuestRecieverID")]
        [InverseProperty("RecievedFriendshipRequests")]
        public virtual Guest GuestReciever { get; set; }        
    }
}
