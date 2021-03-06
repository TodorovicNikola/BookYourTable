﻿using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Models
{
    public class TableBLL
    {
        public int TableID { get; set; }
        public int RestaurantID { get; set; }

        public int? Capacity { get; set; }
        public int CellNumber { get; set; }

        public String Description { get; set; }

        public List<ReservationRealizationBLL> ReservationRealizationBLL;

        public TableBLL() { }

        public TableBLL(Table table)
        {
            TableID = table.TableID;
            RestaurantID = table.RestaurantID;
            Capacity = table.Capacity;
            CellNumber = table.CellNumber;
            Description = table.Description;

            ReservationRealizationBLL = new List<ReservationRealizationBLL>();
            if(table.ReservationRealizations != null)
            {
                foreach (ReservationRealization r in table.ReservationRealizations)
                {
                    ReservationRealizationBLL.Add(new ReservationRealizationBLL(r));
                }
            }

        }
    }
}
