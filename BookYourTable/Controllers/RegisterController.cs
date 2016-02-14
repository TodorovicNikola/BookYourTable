using BookYourTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookYourTable.BLL.Handlers;
using System.Net.Mail;
using System.Threading.Tasks;
using BookYourTable.BLL.Models;

namespace BookYourTable.Controllers
{
    public class RegisterController : Controller
    {
        private RegisterHandlerBLL _registerHandlerBLL = new RegisterHandlerBLL();

       [HttpGet]
        public ActionResult RegisterGuest()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<ActionResult> RegisterGuest(User user)
        {
            if(user.Password != null && user.ConfirmPassword != null)
            {
                if (!user.Password.Equals(user.ConfirmPassword))
                {
                    ModelState.AddModelError("ConfirmPassword", "Password and Confirm Password do not match!");
                }
            }

            if(user.E_Mail != null)
            {
                if (_registerHandlerBLL.E_MailExists(user.E_Mail))
                {
                    ModelState.AddModelError("E_Mail", "E-Mail already exists!");
                }
            }
            
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _registerHandlerBLL.RegisterGuest(user.E_Mail, user.Password, user.FirstName, user.LastName, user.Address);

            var usernameBytes = System.Text.Encoding.UTF8.GetBytes(user.E_Mail);
            String encodedEmail = System.Convert.ToBase64String(usernameBytes);

            string body = "http://localhost:50353/Register/ConfirmRegistration?id=" + encodedEmail;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("nikola58tod@gmail.com");
            mail.To.Add(user.E_Mail);
            mail.Subject = "Confirmation Mail";
            mail.Body = "Hello!\n\tTo finish Your registration, please click on the following link: " + body;

            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(mail);
            }

            return RedirectToAction("ConfirmationNeeded", "Register");
        }

        public ActionResult ConfirmRegistration(String id)
        {
            byte[] data = Convert.FromBase64String(id);
            string decodedEmail = System.Text.Encoding.UTF8.GetString(data);

            _registerHandlerBLL.ConfirmRegistration(decodedEmail);

            return RedirectToAction("ConfirmationSucceeded", "Register");
        }

        public ActionResult ConfirmationNeeded()
        {
            return View();
        }

        public ActionResult ConfirmationSucceeded()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterRestaurant()
        {
            return View(new Restaurant());
        }

        [HttpPost]
        public ActionResult RegisterRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }

            _registerHandlerBLL.RegisterRestaurant(restaurant.Name, restaurant.Description, restaurant.Address);

            TempData["Visibility"] = "visible";
            TempData["Message"] = "Successfully Added New Restaurant!";
            return RedirectToAction("Index", "Restaurant");
        }

        [HttpGet]
        public ActionResult RegisterRestaurantManager(int restaurantID)
        {
            UserBLL user = (UserBLL)Session["user"];

            if (user != null && user.Discriminator.Equals("SystemManager"))
            {
                ViewData["RestaurantID"] = restaurantID;
                return View(new User());
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RegisterRestaurantManager(User user)
        {
            if (user.Password != null && user.ConfirmPassword != null)
            {
                if (!user.Password.Equals(user.ConfirmPassword))
                {
                    ModelState.AddModelError("ConfirmPassword", "Password and Confirm Password do not match!");
                }
            }

            if (user.E_Mail != null)
            {
                if (_registerHandlerBLL.E_MailExists(user.E_Mail))
                {
                    ModelState.AddModelError("E_Mail", "E-Mail already exists!");
                }
            }

            if (!ModelState.IsValid)
            {
                ViewData["RestaurantID"] = user.RestaurantID;
                return View(user);
            }

            _registerHandlerBLL.RegisterRestaurantManager(user.E_Mail, user.Password, user.FirstName, user.LastName, user.RestaurantID);
            TempData["Visibility"] = "visible";
            TempData["Message"] = "Successfully Added New Manager!";
            return RedirectToAction("Index", "Restaurant");
        }
    }
}