using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult loginform(FormCollection collection)
        {
            string email = collection.Get("email");
            string Password = collection.Get("Password");
            if (email == "moiz@gmail.com" && Password == "abc123")
            {
                return RedirectToAction("Index", "AddProduct");
            }
            else
            {
                ViewBag.Message = "Please enter valid Email ID and Password";

            }
            return View("Login");
        }
    }
}