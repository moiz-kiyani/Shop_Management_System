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
        private readonly ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
        }

                    /*This is a connection for Ado.Net*/
        //private readonly UserRepository db = new UserRepository();

        // GET: Admin/Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            UserRepository userRepository = new UserRepository(_context);
            if (ModelState.IsValid)
            {
                if(userRepository.Signin(user.Email,user.Password))
                {
                    //Session["Email"]= user.Email;
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
            UserRepository userRepository = new UserRepository(_context);
            if (ModelState.IsValid)
            {
                userRepository.Signup(user);
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