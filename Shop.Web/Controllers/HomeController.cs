using Shop.Data.Models;
using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            ProductRepository productRepository = new ProductRepository(_context);
            var model = productRepository.GetAll();
            return View(model);
        }

    }
}