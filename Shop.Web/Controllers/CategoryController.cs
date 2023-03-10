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

        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        public CategoryController()
        {
            categoryRepo = new CategoryRepository();
            productRepo = new ProductRepository();
        }

        public ActionResult Categories()
        {
            var model = categoryRepo.GetAll();
            return View(model);
        }

        public ActionResult CategoryProducts(int id)
        {
            var model = productRepo.GetForCategory(id);
            return View(model);
        }
    }
}