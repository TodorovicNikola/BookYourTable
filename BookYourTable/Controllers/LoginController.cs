using BookYourTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookYourTable.BLL.Handlers;
using BookYourTable.BLL.Models;

namespace BookYourTable.Controllers
{
    public class LoginController : Controller
    {
        LoginHandlerBLL _loginHandlerBLL = new LoginHandlerBLL();

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["Visibility"] = "hidden";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string e_mail, string password)
        {
            string message;

            UserBLL userBLL = _loginHandlerBLL.loginAttempt(e_mail, password, out message);

            if (userBLL != null)
            {
                Session["user"] = userBLL;

                if (userBLL.Discriminator.Equals("Guest"))
                {
                    return RedirectToAction("Index", "Home");
                }

                if (userBLL.Discriminator.Equals("RestaurantManager"))
                {
                    return RedirectToAction("Single", "Restaurant");
                }

                return RedirectToAction("Index", "Restaurant");
                
            }
            else
            {
                ViewData["Visibility"] = "visible";
                ViewData["Message"] = message;
            }


            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}