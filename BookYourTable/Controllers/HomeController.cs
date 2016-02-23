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
        RateHandlerBLL _rateHandler = new RateHandlerBLL();

        public ActionResult Index()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            UserBLL user = (UserBLL)Session["user"];

            if (user.Discriminator.Equals("Guest"))
            {
                List<InvitationBLL> invitations = _rateHandler.AcquireAcceptedPastInvitations(user.UserID);
                return View(invitations);
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

        public ActionResult Seed()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            UserBLL user = (UserBLL)Session["user"];

            if (user.Discriminator.Equals("SystemManager"))
            {
                SeedHandlerBLL seedHandler = new SeedHandlerBLL();
                seedHandler.SeedDB();
                
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Rate(int mark, int reservationID)
        {
            UserBLL user = (UserBLL)Session["user"];

            _rateHandler.Rate(mark, reservationID, user.UserID);
            return RedirectToAction("Index", "Home");
        }
    }
}