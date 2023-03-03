using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class CartController : Controller
    {
        IProductRepository productRepo;
        public CartController()
            {
                productRepo = new ProductRepository();
            }

        // GET: Cart
        public ActionResult Index()
        {
            int count = 0;
            var products = Session["Products"] as List<int>;
            if (products != null)
            {
                count = products.Count;
            }

            ViewBag.Count = count;

            return View();
        }

        public ActionResult Cart(int id)
        {
            var model = productRepo.SendToCart(id); 
            return View(model);
        }

        public ActionResult AddToCart(int id)
        {
            // do some code
            var products = Session["Products"] as List<int>;
            if (products == null)
            {
                products = new List<int>();
            }

            products.Add(id);
            Session["Products"] = products;

            return RedirectToAction("Index");
        }
    }
}