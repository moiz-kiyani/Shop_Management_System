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
        
        IProductRepository productRepo;
        public HomeController()
        {
            productRepo = new ProductRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = productRepo.GetAll();
            return View(model);
        }

    }
}