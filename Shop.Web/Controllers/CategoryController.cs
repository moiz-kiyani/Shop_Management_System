using Shop.Data.Models;
using Shop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        /*This is a connection for Ado.Net*/
        //private readonly CategoryRepository db = new CategoryRepository();
        //private readonly ProductRepository productRepository = new ProductRepository();


        //IProductRepository productRepo;
        //ICategoryRepository categoryRepo;
        //public CategoryController()
        //{
        //    categoryRepo = new CategoryRepository();
        //    productRepo = new ProductRepository();
        //}

        public ActionResult Categories()
        {
            CategoryRepository categoryRepository = new CategoryRepository(_context);
            var model = categoryRepository.GetAll();
            return View(model);
        }

        public ActionResult CategoryProducts(int id)
        {
            ProductRepository productRepository = new ProductRepository(_context);
            var model = productRepository.GetForCategory(id);
            return View(model);
        }
    }
}