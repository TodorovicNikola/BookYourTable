using BookYourTable.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.DAL.Handlers
{
    public class RegisterHandlerDAL
    {
        private BookYourTableDBContext _context = new BookYourTableDBContext();

        public bool E_MailExists(String e_mail)
        {
            if(_context.Users.Any(u => u.E_Mail == e_mail))
            {
                return true;
            }

            return false;   
        }

        public void RegisterGuest(String e_mail, String password, String firstName, String lastName, String address)
        {
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            String encodedPassword = System.Convert.ToBase64String(passwordBytes);

            _context.Users.Add(new Guest { E_Mail = e_mail, Password = encodedPassword, FirstName = firstName, LastName = lastName, Address = address, ConfirmedRegistration = false});
            _context.SaveChanges();
        }

        public void ConfirmRegistration(String e_mail)
        {
            Guest guest = _context.Guests.Where(u => u.E_Mail == e_mail).First();

            if(guest != null)
            {
                guest.ConfirmedRegistration = true;
                _context.SaveChanges();
            }
        }

        public void RegisterRestaurant(string name, string description, string address)
        {
            _context.Restaurants.Add(new Restaurant { Name = name, Description = description, Address = address });
            _context.SaveChanges();
        }

        public void RegisterRestaurantManager(string e_mail, string password, string firstName, string lastName, int? restaurantID)
        {
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            String encodedPassword = System.Convert.ToBase64String(passwordBytes);

            _context.RestaurantManagers.Add(new RestaurantManager { E_Mail = e_mail, Password = encodedPassword, FirstName = firstName, LastName = lastName, RestaurantID = (int)restaurantID });
            _context.SaveChanges();
        }
    }
}
