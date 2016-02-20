using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookYourTable.BLL.Handlers;
using BookYourTable.Models;
using BookYourTable.BLL.Models;

namespace BookYourTable.Controllers
{
    public class HomeController : Controller
    {
        RestaurantHandlerBLL _restaurantHandler = new RestaurantHandlerBLL();

        public ActionResult Index()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            UserBLL user = (UserBLL)Session["user"];

            if (user.Discriminator.Equals("Guest"))
            {
                return View();
            }
            else if (user.Discriminator.Equals("SystemManager"))
            {
                return RedirectToAction("Index", "Restaurant");
            }
            else
            {
                return RedirectToAction("Single", "Restaurant");
            }
            
        }
    }
}