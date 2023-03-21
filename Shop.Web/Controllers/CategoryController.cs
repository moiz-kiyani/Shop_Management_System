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
        private readonly CategoryRepository db = new CategoryRepository();
        private readonly ProductRepository productRepository = new ProductRepository();
        

        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        public CategoryController()
        {
            categoryRepo = new CategoryRepository();
            productRepo = new ProductRepository();
        }

        public ActionResult Categories()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult CategoryProducts(int id)
        {
            var model = productRepository.GetForCategory(id);
            return View(model);
        }
    }
}