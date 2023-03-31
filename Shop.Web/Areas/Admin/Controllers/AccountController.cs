using NHibernate.Cfg;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.Data.Services;
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
        private readonly UserRepository _userRepository;

        public AccountController()
        {

            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            _userRepository = new UserRepository(session);

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if(_userRepository.Signin(user.Email,user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }
            return View(user);
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
            if (ModelState.IsValid)
            {
                _userRepository.Signup(user);
                return RedirectToAction("Login");
            }
            return RedirectToAction("signup");
        }

        [HttpPost]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}