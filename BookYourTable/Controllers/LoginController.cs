using BookYourTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookYourTable.BLL.Handlers;

namespace BookYourTable.Controllers
{
    public class LoginController : Controller
    {
        LoginHandlerBLL _loginHandlerBLL;

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["Visibility"] = "hidden";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string e_mail, string password)
        {
            

            ViewData["Visibility"] = "visible";
            ViewData["Message"] = e_mail + " " + password;

            return View();
        }
    }
}