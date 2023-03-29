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
        private readonly ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        /*This is a connection for Ado.Net*/
        //private readonly ProductRepository db = new ProductRepository();


        //IProductRepository db;
        //public ProductController()
        //{
        //   db = new ProductRepository();
        //}
        // GET: Product

        public ActionResult Index()
        {
            ProductRepository productRepository = new ProductRepository(_context);
            var model = productRepository.GetAll();
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            ProductRepository productRepository = new ProductRepository(_context);
            var model = productRepository.Get(id);

            return View(model);
        }
        public ActionResult Search(string search)
        {
            ProductRepository productRepository = new ProductRepository(_context);
            var model = productRepository.Search(search);

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Search(string search)
        //{
        //    var model = db.Search(search);
        //    return View(model);
        //}
    }
}