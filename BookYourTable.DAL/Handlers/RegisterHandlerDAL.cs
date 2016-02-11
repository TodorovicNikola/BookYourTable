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
            Guest guest = new Guest();
            guest.E_Mail = e_mail;
            guest.Password = password;
            guest.FirstName = firstName;
            guest.LastName = lastName;
            guest.Address = address;
            guest.ConfirmedRegistration = false;

            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(guest.Password);
            String encodedPassword = System.Convert.ToBase64String(passwordBytes);
            guest.Password = encodedPassword;

            _context.Users.Add(guest);
            _context.SaveChanges();
        }

        public void ConfirmRegistration(String e_mail)
        {
            User user = _context.Users.Where(u => u.E_Mail == e_mail).First();

            if(user != null)
            {
                user.ConfirmedRegistration = true;
                _context.SaveChanges();
            }
        }
    }
}
