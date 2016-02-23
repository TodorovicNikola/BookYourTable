using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookYourTable.DAL.Handlers
{
    public class SeedHandler
    {
        public SeedHandler() { }

        public void SeedDB()
        {
            BookYourTableDBContext context = new BookYourTableDBContext();

            foreach(Table table in context.Tables.ToList())
            {
                for(int i=9; i < 24; i++)
                {
                    ReservationRealization r1 = new ReservationRealization();
                    r1.RestaurantID = table.RestaurantID;
                    r1.TableID = table.TableID;
                    r1.Time = i;
                    r1.Date = DateTime.Today;
                    context.ReservationRealizations.Add(r1);

                    ReservationRealization r2 = new ReservationRealization();
                    r2.RestaurantID = table.RestaurantID;
                    r2.TableID = table.TableID;
                    r2.Time = i;
                    r2.Date = DateTime.Now.AddDays(1).Date;
                    context.ReservationRealizations.Add(r2);

                    ReservationRealization r3 = new ReservationRealization();
                    r3.RestaurantID = table.RestaurantID;
                    r3.TableID = table.TableID;
                    r3.Time = i;
                    r3.Date = DateTime.Now.AddDays(2).Date;
                    context.ReservationRealizations.Add(r3);

                    ReservationRealization r4 = new ReservationRealization();
                    r4.RestaurantID = table.RestaurantID;
                    r4.TableID = table.TableID;
                    r4.Time = i;
                    r4.Date = DateTime.Now.AddDays(3).Date;
                    context.ReservationRealizations.Add(r4);
                }   
            }
            context.SaveChanges();
        }
    }
}
