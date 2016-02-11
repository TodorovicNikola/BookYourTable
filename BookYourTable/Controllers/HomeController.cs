using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookYourTable.BLL.Handlers;
using BookYourTable.Models;

namespace BookYourTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["User"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}