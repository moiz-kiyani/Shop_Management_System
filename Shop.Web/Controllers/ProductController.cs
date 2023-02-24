using Shop.Data.Models;
using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProducts db;
        public ProductController()
        {
           db = new InMemoryData();
        }
        // GET: Product
        
        public ActionResult Index()
        {
            var model = db.GetAll();
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            return View(model);
        }
    }
}