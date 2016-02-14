using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookYourTable.DAL.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookYourTable.DAL
{
    public class BookYourTableDBContext : DbContext
    {
        public BookYourTableDBContext()
            : base("Book_Your_Table")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SystemManager> SystemManagers { get; set; }
        public virtual DbSet<RestaurantManager> RestaurantManagers { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<MenuItem>().Property(x => x.Price).HasPrecision(6, 2);
        }

    }
}
