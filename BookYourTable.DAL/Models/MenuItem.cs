using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookYourTable.DAL.Models
{
    public class MenuItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuItemID { get; set; }

        [Key]
        [ForeignKey("Restaurant")]
        [Column(Order = 1)]
        public int RestaurantID { get; set; }

        [Required]
        [StringLength(64)]
        public String Name { get; set; }

        [StringLength(2048)]
        public String Description { get; set; }

        [Required]
        public Decimal Price { get; set; }
        
        [StringLength(128)]
        public String ImgUrl { get; set; }

        [ForeignKey("RestaurantID")]
        public virtual Restaurant Restaurant { get; set; }

        
    }
}
