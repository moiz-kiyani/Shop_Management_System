using Shop.Data.Models;
using Shop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository db = new UserRepository();

        // GET: Admin/Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (db.Signin(user))
            db.Signin(user);
           return RedirectToAction("Menu", "Account");
            
            return View("Login");
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if(ModelState.IsValid)
            {
                db.Signup(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}