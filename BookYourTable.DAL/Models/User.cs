using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookYourTable.DAL.Models
{
    public class User
    {
        public int UserID { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        [StringLength(64)]
        public String E_Mail { get; set; }

        [Required]
        [StringLength(64)]
        public String Password { get; set; }

        [StringLength(32)]
        public String FirstName { get; set; }

        [StringLength(32)]
        public String LastName { get; set; }
    }
}
