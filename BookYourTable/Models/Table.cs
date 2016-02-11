using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookYourTable.Models
{
    public class Table
    {
        public int TableID { get; set; }
        public int RestaurantID { get; set; }

        public int Capacity { get; set; }

        [Required(ErrorMessage = "Cell Number of the table cannot be empty")]
        public int CellNumber { get; set; }

        [StringLength(128, ErrorMessage = "Description cannot be longer than 128 characters!")]
        public String Description { get; set; }

        
    }
}