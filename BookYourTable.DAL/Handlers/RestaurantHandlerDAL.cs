using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace BookYourTable.DAL.Handlers
{
    public class RestaurantHandlerDAL
    {
        private BookYourTableDBContext _context = new BookYourTableDBContext();

        public List<Restaurant> AcquireAllRestaurants(String discriminator, bool sortType)//true - name, false - description
        {
            if (discriminator.Equals("SystemManager"))
            {
                if (sortType)
                {
                    return _context.Restaurants.OrderBy(r => r.Name).ToList();
                }
                else
                {
                    return _context.Restaurants.OrderBy(r => r.Description).ToList();
                }
                
            }

            if (sortType)
            {
                return _context.Restaurants.OrderBy(r => r.Name).Where(u => u.Configured == true).ToList();
            }
            else
            {
                return _context.Restaurants.OrderBy(r => r.Description).Where(u => u.Configured == true).ToList();
            }

            
        }

        public Restaurant AcquireRestaurant(int? restaurantID)
        {
            return _context.Restaurants.Include(x => x.Tables).Include(x => x.MenuItems).Where(r => r.RestaurantID == restaurantID).First();
        }

        public void EditRestaurant(int restaurantID, String name, String description, String address)
        {
            var restaurant = _context.Restaurants.Find(restaurantID);

            restaurant.Name = name;
            restaurant.Description = description;
            restaurant.Address = address;

            _context.SaveChanges();
        }

        public void RemoveRestaurant(int restaurantID)
        {
            _context.Restaurants.Find(restaurantID).Configured = false;
            _context.SaveChanges();
        }

        public RestaurantManager ConfigureTables(int restaurantID, List<int> tableIndexes, int width, int height, int userID)
        {
            List<Table> tables = new List<Table>();

            foreach(int tableIndex in tableIndexes)
            {
                Table table = new Table() { RestaurantID = restaurantID, CellNumber = tableIndex };
                tables.Add(table);
            }

            _context.Tables.AddRange(tables);

            Restaurant restaurant = _context.Restaurants.Find(restaurantID);
            restaurant.TablesMatrixWidth = width;
            restaurant.TablesMatrixHeight = height;
            restaurant.Configured = true;

            _context.SaveChanges();

            return _context.RestaurantManagers.Include(r => r.Restaurant).Where(r => r.UserID == userID).First();
        }

        public Restaurant AcquireRestaurantForBooking(int restaurantID)
        {
            Restaurant retVal = _context.Restaurants.Where(r => r.RestaurantID == restaurantID).Include(t => t.Tables.Select(r => r.ReservationRealizations)).First();

            foreach (Table table in retVal.Tables.ToList())
            {
                foreach(ReservationRealization r in table.ReservationRealizations.ToList())
                {
                    if(r.Date != DateTime.Today || r.Time != 19.00m)
                    {
                        table.ReservationRealizations.Remove(r);
                        continue;
                    }
                }
            }


            return retVal;
        }


        public Restaurant AcquireRestaurantForBooking(int restaurantID, String date, String time, int duration)
        {
            string[] split = time.Split(':');
            decimal timeDecimal = Convert.ToDecimal(split[0]);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            Restaurant retVal = _context.Restaurants.Where(r => r.RestaurantID == restaurantID).Include(t => t.Tables.Select(r => r.ReservationRealizations)).First();

            foreach (Table table in retVal.Tables.ToList())
            {
                foreach (ReservationRealization r in table.ReservationRealizations.ToList())
                {
                    if (r.Date.ToString("d").Equals(date))
                    {
                        bool belongs = false;

                        for(int i = 0; i < duration; i++)
                        {
                            if(r.Time == timeDecimal + i)
                            {
                                belongs = true;
                            }
                        }

                        if (!belongs)
                        {
                            table.ReservationRealizations.Remove(r);
                            continue;
                        }

                    }else
                    {
                        table.ReservationRealizations.Remove(r);
                        continue;
                    }
                }
            }

            return retVal;
        }

        public int ConfirmBookingTable(List<int> tableIndexes, int restaurantID, String date, String time, int duration, int userID, out Guest guest, out int? reservationID)
        {
            string[] split = time.Split(':');
            decimal timeDecimal = Convert.ToDecimal(split[0]);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            DateTime givenDateGBFormat = Convert.ToDateTime(date);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            if(givenDateGBFormat.Date == DateTime.Today.Date)
            {
                String d = DateTime.Now.Hour.ToString();
                if (Convert.ToDecimal(d) >= timeDecimal)
                {
                    guest = null;
                    reservationID = 0;
                    return 2;
                }
            }


            List<ReservationRealization> selectedReservations = new List<ReservationRealization>();

            try
            {


                if (duration == 1)
                {
                    selectedReservations = (from t in _context.Tables
                                            from r in t.ReservationRealizations
                                            where EntityFunctions.TruncateTime(r.Date) == EntityFunctions.TruncateTime(givenDateGBFormat) && r.RestaurantID == restaurantID && r.Time == timeDecimal
                                            select r).Include(r => r.Table).ToList();
                } else if (duration == 2)
                {
                    selectedReservations = (from t in _context.Tables
                                            from r in t.ReservationRealizations
                                            where EntityFunctions.TruncateTime(r.Date) == EntityFunctions.TruncateTime(givenDateGBFormat) && r.RestaurantID == restaurantID && (r.Time == timeDecimal || r.Time == timeDecimal + 1)
                                            select r).Include(r => r.Table).ToList();
                } else if (duration == 3)
                {
                    selectedReservations = (from t in _context.Tables
                                            from r in t.ReservationRealizations
                                            where EntityFunctions.TruncateTime(r.Date) == EntityFunctions.TruncateTime(givenDateGBFormat) && r.RestaurantID == restaurantID && (r.Time == timeDecimal || r.Time == timeDecimal + 1 || r.Time == timeDecimal + 2)
                                            select r).Include(r => r.Table).ToList();
                }
                else
                {
                    selectedReservations = (from t in _context.Tables
                                            from r in t.ReservationRealizations
                                            where EntityFunctions.TruncateTime(r.Date) == EntityFunctions.TruncateTime(givenDateGBFormat) && r.RestaurantID == restaurantID && r.Time == timeDecimal || r.Time == timeDecimal + 1 || r.Time == timeDecimal + 2 || r.Time == timeDecimal + 3
                                            select r).Include(r => r.Table).ToList();
                }

                foreach (ReservationRealization r in selectedReservations)
                {
                    foreach (int n in tableIndexes)
                    {
                        if (r.Table.CellNumber == n)
                        {
                            if (r.ReservationID != null)
                            {
                                guest = null;
                                reservationID = 0;

                                return 1;
                            }
                        }

                    }
                }

                Reservation reservation = new Reservation { GuestID = userID, RestaurantID = restaurantID, ReservationDate = givenDateGBFormat };
                _context.Reservations.Add(reservation);

                foreach (ReservationRealization r in selectedReservations)
                {
                    foreach (int n in tableIndexes)
                    {
                        if (r.Table.CellNumber == n)
                        {
                            r.ReservationID = reservation.ReservationID;
                        }

                    }
                }

                _context.SaveChanges();

                guest = _context.Guests.Where(g => g.UserID == userID).Include(g => g.SentFriendshipRequests).Include(g => g.RecievedFriendshipRequests).First();
                reservationID = reservation.ReservationID;

                Invitation invitation = new Invitation() { ReservationID = (int)reservationID, GuestID = userID, Accepted = true};
                _context.Invitations.Add(invitation);
                _context.SaveChanges();
                return 0;


            }
            catch(DbUpdateConcurrencyException ex)
            {
                guest = null;
                reservationID = 1;

                return 1;
            }  
        }

        public void Invite(List<int> friendsIDsList, int reservationID)
        {
            foreach (int friendID in friendsIDsList)
            {
                Invitation invitation = new Invitation() { ReservationID = reservationID, GuestID = friendID, Accepted = null };
                _context.Invitations.Add(invitation);
                
            }

            _context.SaveChanges();
        }

        public void RespondToInvitation(int? userID, int? reservationID, Boolean response)
        {
            Invitation invitation = _context.Invitations.Where(i => i.GuestID == userID && i.ReservationID == reservationID).First();
            invitation.Accepted = response;
            _context.SaveChanges();
        }

        public Decimal AcquaireAverageRating(int? restaurantID)
        {
            Decimal totalGrades = Convert.ToDecimal((from i in _context.Invitations
                                   where i.Reservation.RestaurantID == restaurantID && i.Grade != null
                                   select i.Grade).DefaultIfEmpty(0).Sum());

            int totalVotes = (from i in _context.Invitations
                              where i.Reservation.RestaurantID == restaurantID && i.Grade != null
                              select i.Grade).DefaultIfEmpty(0).Count();

            if(totalGrades != 0 || totalVotes != 0)
            {
                return totalGrades / totalVotes;
            }
            else
            {
                return 0;
            }
        }

        public Decimal AcquaireAverageRatingUser(int? restaurantID, int? userID)
        {
            List<Guest> friends = new List<Guest>();

            int totalVotes = 0;
            Decimal totalGrades = 0;

            Guest user = _context.Guests.Where(g => g.UserID == userID).Include(g => g.SentFriendshipRequests).Include(g => g.RecievedFriendshipRequests).First();

            friends.Add(user);

            foreach(Friendship f in user.SentFriendshipRequests)
            {
                if(f.Confirmed == true)
                {
                    friends.Add(f.GuestReciever);
                }
            }

            foreach (Friendship f in user.RecievedFriendshipRequests)
            {
                if (f.Confirmed == true)
                {
                    friends.Add(f.GuestSender);
                }
            }


            List<Invitation> invitations = _context.Invitations.Where(i => i.Grade != null).ToList();

            foreach(Invitation inv in invitations)
            {
                foreach(Guest g in friends)
                {
                    if(inv.GuestID == g.UserID && inv.Reservation.RestaurantID == restaurantID)
                    {
                        totalGrades += (int)inv.Grade;
                        totalVotes++;
                    }
                }
            }

            if (totalGrades != 0 || totalVotes != 0)
            {
                return totalGrades / totalVotes;
            }
            else
            {
                return 0;
            }

        }
    }
}
