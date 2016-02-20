using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class RestaurantBLL
    {
        public int RestaurantID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImgUrl { get; set; }
        public String Address { get; set; }
        public Boolean Configured { get; set; }
        public int? TablesMatrixWidth { get; set; }
        public int? TablesMatrixHeight { get; set; }
        public List<TableBLL> Tables { get; set; }

        public RestaurantBLL(Restaurant restaurantDAL)
        {
            Tables = new List<TableBLL>();

            RestaurantID = restaurantDAL.RestaurantID;
            Name = restaurantDAL.Name;
            Description = restaurantDAL.Description;
            ImgUrl = restaurantDAL.ImgUrl;
            Address = restaurantDAL.Address;
            TablesMatrixWidth = restaurantDAL.TablesMatrixWidth;
            TablesMatrixHeight = restaurantDAL.TablesMatrixHeight;
            Configured = restaurantDAL.Configured;

            if(restaurantDAL.Tables != null)
            {
                foreach(Table table in restaurantDAL.Tables)
                {
                    Tables.Add(new TableBLL(table));
                }
            }
        }

    }
}
