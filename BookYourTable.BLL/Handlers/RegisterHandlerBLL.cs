using BookYourTable.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourTable.BLL.Handlers
{
    public class RegisterHandlerBLL
    {
        private RegisterHandlerDAL _registerHandlerDAL = new RegisterHandlerDAL();

        public bool E_MailExists(String e_mail)
        {
            return _registerHandlerDAL.E_MailExists(e_mail);
        }

        public void RegisterGuest(String e_mail, String password, String firstName, String lastName, String address)
        {
            _registerHandlerDAL.RegisterGuest(e_mail, password, firstName, lastName, address);
        }

        public void ConfirmRegistration(String e_mail)
        {
            _registerHandlerDAL.ConfirmRegistration(e_mail);
        }

        public void RegisterRestaurant(string name, string description, string address)
        {
            _registerHandlerDAL.RegisterRestaurant(name, description, address);
        }

        public void RegisterRestaurantManager(string e_mail, string password, string firstName, string lastName, int? restaurantID)
        {
            _registerHandlerDAL.RegisterRestaurantManager(e_mail, password, firstName, lastName, restaurantID);
        }
    }
}
