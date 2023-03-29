//using Shop.Data.Models;
//using Shop.Data.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Shop.Web.Controllers
//{
//    public class CartController : Controller
//    {
//        IProductRepository productRepo;
//        public CartController()
//            {
//                productRepo = new ProductRepository();
//            }

//        List<Product> li = new List<Product>();

//        // GET: Cart
//        public ActionResult Index()
//        {
//            int x = 0;
//            int count = 0;
//            var products = Session["Products"] as List<int>;
//            if (products != null)
//            {
//                count = products.Count;
//            }
//            else
//            {
//                return RedirectToAction("CartIsEmpty");
//            }

//            var models = productRepo.GetAll().Where(p => products.Contains(p.Id)).ToList();
//            foreach(var item in models)
//            {
//                x += item.Price;
//            }
            
//            ViewBag.Total = x;
//            ViewBag.Count = count;

//            return View(models);
//        }

//        public ActionResult CartIsEmpty()
//        { 
//            return View();
//        }

//        public ActionResult SendToCart(int id)
//        {
//            var model = productRepo.SendToCart(id);
//            var products = Session["Products"] as List<int>;
//            if (products == null)
//            {
//                products = new List<int>();
//            }

//            products.Add(id);
//            Session["Products"] = products;

//            return RedirectToAction("Index");
//        }
//    }
//}